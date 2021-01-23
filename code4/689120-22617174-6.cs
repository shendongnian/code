    EndpointAddress endpoint = new EndpointAddress("http://localhost:9001/Message");
    WebServiceHost svcWebHost = new WebServiceHost(typeof(Service.Message), endpoint.Uri);
    CustomServiceBehavior serviceBehavior = new CustomServiceBehavior();
    svcWebHost.Description.Behaviors.Add(serviceBehavior);
    Binding webHttpBinding = new WebHttpBinding();
                        
    ServiceEndpoint serviceEndpoint = svcWebHost.AddServiceEndpoint(typeof(Service.IMessage), webHttpBinding, endpoint.Uri);
            
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    svcWebHost.Description.Behaviors.Add(smb);
    ServiceDebugBehavior sdb = svcWebHost.Description.Behaviors.Find<ServiceDebugBehavior>();
    sdb.IncludeExceptionDetailInFaults = true;
            
    svcWebHost.Open();
