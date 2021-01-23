    Uri baseAddress = new Uri("http://localhost:8001/HelloWorld");
        // Create the ServiceHost.
        using (serviceHost = new ServiceHost(typeof(HelloWorldService), baseAddress))
        {
            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            serviceHost.Description.Behaviors.Add(smb);
            // Open the ServiceHost to start listening for messages. Since
            // no endpoints are explicitly configured, the runtime will create
            // one endpoint per base address for each service contract implemented
            // by the service.
            serviceHost.AddServiceEndpoint(typeof(IHelloWorldService), new WSHttpBinding(), "");
            serviceHost.Open();
              
        }
