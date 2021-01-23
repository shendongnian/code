    using System;
    using SignalR.Hubs;
    
    namespace SignalR.Hosting.Self.Samples {
        class Program {
            static void Main(string[] args) {
                string url = "http://127.0.0.1:8088/";
                var server = new Server(url);
    
                // Map the default hub url (/signalr)
                server.MapHubs();
    
                // Start the server
                server.Start();
    
                Console.WriteLine("Server running on {0}", url);
    
                // Keep going until somebody hits 'x'
                while (true) {
                    ConsoleKeyInfo ki = Console.ReadKey(true);
                    if (ki.Key == ConsoleKey.X) {
                        break;
                    }
                }
            }
    
            [HubName("CustomHub")]
            public class MyHub : Hub {
                public string Send(string message) {
                    return message;
                }
    
                public void DoSomething(string param) {
                    Clients.addMessage(param);
                }
            }
        }
    }
