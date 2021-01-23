    static void Main(string[] args)
    {
        var channelFactory = new WcfChannelFactory<IPrestoService>(new NetTcpBinding());
        var endpointAddress = ConfigurationManager.AppSettings["endpointAddress"];
        // The call to CreateChannel() actually returns a proxy that can intercept calls to the
        // service. This is done so that the proxy can retry on communication failures.            
        IPrestoService prestoService = channelFactory.CreateChannel(new EndpointAddress(endpointAddress));
        Console.WriteLine("Enter some information to echo to the Presto service:");
        string message = Console.ReadLine();
        string returnMessage = prestoService.Echo(message);
        Console.WriteLine("Presto responds: {0}", returnMessage);
        Console.WriteLine("Press any key to stop the program.");
        Console.ReadKey();
    }
