    using System;
    using System.IO;
    using System.IO.Pipes;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                StartServer();
                Task.Delay(1000).Wait();
                //Client
                var client = new NamedPipeClientStream("PipesOfPiece");
                client.Connect();
                StreamReader reader = new StreamReader(client);
                StreamWriter writer = new StreamWriter(client);
                while (true)
                {
                    string input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input)) break;
                    writer.WriteLine(input);
                    writer.Flush();
                    Console.WriteLine(reader.ReadLine());
                }
            }
            static void StartServer()
            {
                Task.Factory.StartNew(() =>
                {
                    var server = new NamedPipeServerStream("PipesOfPiece");
                    server.WaitForConnection();
                    StreamReader reader = new StreamReader(server);
                    StreamWriter writer = new StreamWriter(server);
                    while (true)
                    {
                        var line = reader.ReadLine();
                        writer.WriteLine(String.Join("", line.Reverse()));
                        writer.Flush();
                    }
                });
            }
        }
    }
