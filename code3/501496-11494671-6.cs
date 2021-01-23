        class Program
        {
            static void Main(string[] args)
            {
                var config = new HttpSelfHostConfiguration("http://localhost:8080");
                config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/html");
                config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
                config.Routes.MapHttpRoute(
                    name: "DefaultApiRoute",
                    routeTemplate: "{controller}/{id}.{ext}",
                    defaults: new { id = RouteParameter.Optional, formatter = RouteParameter.Optional },
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
