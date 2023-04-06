using System;
using System.Collections.Generic;

namespace CalculoDespesasMensais
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Gasto> gastos = new List<Gasto>();
            string continuar;

            do
            {
                Console.WriteLine("Informe o tipo de conta (ex: Aluguel, Luz, Água):");
                string tipoConta = ObterEntradaString();

                Console.WriteLine("Informe o valor do gasto (ex: 1000,50):");
                double valor = ObterEntradaDouble();

                gastos.Add(new Gasto(tipoConta, valor));

                Console.WriteLine("Deseja adicionar mais um gasto? (S/N)");
                continuar = ObterEntradaString().ToUpper();

            } while (continuar == "S");

            double totalGastos = 0;

            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|{0,-20} | {1,-20} |", "Tipo de Conta", "Valor");
            Console.WriteLine("-------------------------------------------------");

            foreach (Gasto gasto in gastos)
            {
                totalGastos += gasto.Valor;

                Console.WriteLine("|{0,-20} | {1,-20:C} |", gasto.TipoConta, gasto.Valor);
            }

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("|{0,-20} | {1,-20:C} |", "Total de Gastos", totalGastos);
            Console.WriteLine("-------------------------------------------------");
        }

        static string ObterEntradaString()
        {
            string entrada;

            do
            {
                Console.Write(">> ");
                entrada = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("Por favor, preencha o campo corretamente.");
                }
            } while (string.IsNullOrWhiteSpace(entrada));

            return entrada;
        }

        static double ObterEntradaDouble()
        {
            double entrada;

            while (true)
            {
                Console.Write(">> R$ ");
                string entradaString = Console.ReadLine().Trim();

                if (double.TryParse(entradaString, out entrada) && entrada >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um valor válido.");
                }
            }

            return entrada;
        }
    }

    class Gasto
    {
        public string TipoConta { get; set; }
        public double Valor { get; set; }

        public Gasto(string tipoConta, double valor)
        {
            TipoConta = tipoConta;
            Valor = valor;
        }
    }
}
