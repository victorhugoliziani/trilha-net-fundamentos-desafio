namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Veiculo veiculo = new Veiculo();
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = Console.ReadLine();
            veiculo.Placa = !string.IsNullOrEmpty(placa) ? placa : string.Empty;
            veiculos.Add(veiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Digite a quantidade de horas que esse veiculo ficou estacionado:");
            decimal qtdHoras = Convert.ToDecimal(Console.ReadLine());

            decimal valorTotal = precoInicial + (precoPorHora * qtdHoras);

            if (veiculos.Count() > 0)
            {
                Veiculo veiculo = (from v in veiculos where v.Placa == placa select v).FirstOrDefault();

                if(veiculo != null)
                {
                    veiculos.Remove(veiculo);
                    Console.WriteLine($"Veiculo excluido com sucesso. Valor a pagar é de: R${valorTotal.ToString("N2")}");
                }
                else
                    Console.WriteLine("Veiculo com essa placa não foi encontrado. Tente novamente");

            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos )
                {
                    Console.WriteLine($"{veiculo.Placa}");               
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
