        static void Main(string[] args)
        {
            string serviceAddress = "net.tcp://localhost:8088/FooBarService";
            ServiceHost selfServiceHost = new ServiceHost(typeof(FooService));            
            // The endpoints need to share this binding.
            var binding = new NetTcpBinding();
            selfServiceHost.AddServiceEndpoint(typeof(IFooService), binding, serviceAddress);
            selfServiceHost.AddServiceEndpoint(typeof(IBarService), binding, serviceAddress);
            selfServiceHost.Open();
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press any key to terminate service.");
            Console.WriteLine();
            Console.ReadKey();
            selfServiceHost.Close();
        }
