    using System;
    namespace MyConsoleApplication
    {
        static class Program
        {
            static void Main(string[] args)
            {
                string url = "http://localhost:8081/";
                var server = new SignalR.Hosting.Self.Server(url);
                // Map the default hub url (/signalr)
                server.MapHubs();
                // Start the server
                server.Start();
                Console.WriteLine("Server running on {0}", url);
                // Keep going until somebody hits 'x'
                while (true)
                {
                    ConsoleKeyInfo ki = Console.ReadKey(true);
                    if (ki.Key == ConsoleKey.X)
                    {
                        break;
                    }
                }
            }
            public class MyHub : SignalR.Hubs.Hub
            {
                public void Send(string message)
                {
                    Clients.addMessage(message);
                }
            }
        }
    }
