    TcpChannel tcp = new TcpChannel(1234);
        ChannelServices.RegisterChannel(tcp,false);
        string s = ConfigurationManager.AppSettings["remote"];
        RemotingConfiguration.RegisterWellKnownServiceType(typeof(InitialClass1),s,WellKnownObjectMode.SingleCall);
        Console.WriteLine("Remoting starting...");
        Console.ReadLine(); 
