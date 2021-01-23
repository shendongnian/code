    [assembly: OwinStartup(typeof(Program.Startup))]
    namespace ConsoleApplication116_SignalRServer
    {
        class Program
        {
            static IDisposable SignalR;
    
            static void Main(string[] args)
            {
                string url = "http://127.0.0.1:8088";
                SignalR = WebApp.Start(url);
    
                Console.ReadKey();
            }
    
            public class Startup
            {
                public void Configuration(IAppBuilder app)
                {
                    app.UseCors(CorsOptions.AllowAll);
                    app.MapSignalR();
                }
            }
    
            [HubName("MyHub")]
            public class MyHub : Hub
            {
                public void Send(string name, string message)
                {
                    Clients.All.addMessage(name, message);
                }
            }
        }
    }
