    namespace NancyApplication1
    {
        using System;
        using Nancy.Hosting.Self;
        class Program
        {
            static void Main(string[] args)
            {
                var uri = new Uri("http://localhost:3579");
                var config = new HostConfiguration();
                // (Change the default RewriteLocalhost value)
                config.RewriteLocalhost = false;
                using (var host = new NancyHost(config, uri))
                {
                    host.Start();
                    Console.WriteLine("Your application is running on " + uri);
                    Console.WriteLine("Press any [Enter] to close the host.");
                    Console.ReadLine();
                }
            }
        }
    }
