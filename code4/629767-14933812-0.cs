        using (var serviceHost = new WebServiceHost(typeof(Swiper), new Uri("https://localhost:8083")))
            {
                var secureWebHttpBinding = new WebHttpBinding(WebHttpSecurityMode.Transport) { Name = "secureHttpWeb" };
                serviceHost.AddServiceEndpoint(typeof(ISwiper), secureWebHttpBinding, "");
                serviceHost.Open();
                Console.WriteLine("Service running...");
                Console.WriteLine("Press any key to stop service.");
                Console.ReadLine();
                // Stop the host
                serviceHost.Close();
            }
