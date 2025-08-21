using System;
using System.Collections.Generic;

public class Tarefa
{
    // Atributos
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    // Construtor
    public Tarefa(string descricao)
    {
        Descricao = descricao;
        Concluida = false;
    }

    // Método para marcar como concluída
    public void MarcarComoConcluida()
    {
        Concluida = true;
    }

    // Mostrar tarefa
    public void MostrarTarefa()
    {
        string status = Concluida ? "✅ Concluída" : "❌ Pendente";
        Console.WriteLine($"{Descricao} - {status}");
    }
}

public class Program
{
    public static void Main()
    {
        List<Tarefa> listaTarefas = new List<Tarefa>();
        int opcao = 0;

        do
        {
            Console.WriteLine("\n===== Gerenciador de Tarefas =====");
            Console.WriteLine("1 - Adicionar nova tarefa");
            Console.WriteLine("2 - Listar tarefas");
            Console.WriteLine("3 - Marcar tarefa como concluída");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
            
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite a descrição da tarefa: ");
                    string descricao = Console.ReadLine();
                    listaTarefas.Add(new Tarefa(descricao));
                    Console.WriteLine("✅ Tarefa adicionada com sucesso!");
                    break;

                case 2:
                    Console.WriteLine("\n--- Lista de Tarefas ---");
                    if (listaTarefas.Count == 0)
                    {
                        Console.WriteLine("Nenhuma tarefa cadastrada.");
                    }
                    else
                    {
                        for (int i = 0; i < listaTarefas.Count; i++)
                        {
                            Console.Write($"{i + 1}. ");
                            listaTarefas[i].MostrarTarefa();
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("\nQual número da tarefa deseja marcar como concluída?");
                    int num = int.Parse(Console.ReadLine()) - 1;
                    if (num >= 0 && num < listaTarefas.Count)
                    {
                        listaTarefas[num].MarcarComoConcluida();
                        Console.WriteLine("✅ Tarefa marcada como concluída!");
                    }
                    else
                    {
                        Console.WriteLine("Número inválido.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente!");
                    break;
            }

        } while (opcao != 4);
    }
}
