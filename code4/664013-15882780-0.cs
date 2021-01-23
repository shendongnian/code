    Uri baseAddress = new Uri("http://localhost:51160");
    WSDualHttpBinding binding = new WSDualHttpBinding();
    using (ServiceHost host = new ServiceHost(typeof(FileServer), baseAddress))
    {
        host.AddServiceEndpoint(typeof(IFileServer), binding, "http://localhost:51160/FileServer");
    
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        host.Description.Behaviors.Add(smb);
    
        host.Open();
        Console.ReadLine();
        host.Close();
    }
