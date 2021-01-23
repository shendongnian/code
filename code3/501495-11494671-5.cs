        class Program
        {
            static void Main(string[] args)
            {
                var config = new HttpSelfHostConfiguration("http://localhost:8080");
                config.Routes.MapHttpRoute(
                    name: "DefaultApiRoute",
                    routeTemplate: "{controller}/{id}.{format}",
                    defaults: new { id = RouteParameter.Optional, format = RouteParameter.Optional },
                    constraints: null
                );
                using (var server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().Wait();
                    Console.WriteLine("Press Enter to quit.");
                    Console.ReadLine();
                }
            }
        }
