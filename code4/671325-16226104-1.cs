    // create service host
    // Note: ServiceHandler is a class you make that implements your service contract interfaces
    ServiceHost host = host = new ServiceHost(typeof(ServiceHandler), new URI("127.0.0.1");
    // enable metadata exchange (creates wsdl URL)
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    host.Description.Behaviors.Add(smb);
    // start the host listening
    host.Open()
