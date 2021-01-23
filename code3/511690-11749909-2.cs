        ChannelFactory<IService1> factory = new ChannelFactory<IService1>(
            new WSHttpBinding(), new EndpointAddress("http://localhost:4213/Service1.svc"));
        IService1 proxy = factory.CreateChannel();
        
        Console.WriteLine(proxy.SessionId());
        
        ((IClientChannel)proxy).Close();
        factory.Close();
        
        Console.Read();
