    public static void Main()
    {
        MyWcfService instance = new MyWcfService();
        using (ServiceHost serviceHost = new ServiceHost(instance))
        {
            var endpoint = serviceHost.AddServiceEndpoint(typeof(IMyWcfService), new NetTcpBinding(), "net.tcp://localhost:8000/MyWcfService");
            serviceHost.Open();
    
            // The service can now be accessed.
            Console.WriteLine("The service is ready at {0}", endpoint.Address);
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
