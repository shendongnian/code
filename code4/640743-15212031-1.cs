    private ServiceHost host;
    public void startSoapServer()
            {
                // trimmed... for clarity
    
                    host = new ServiceHost(typeof(SoapServer), baseAddress));
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    host.Description.Behaviors.Add(smb);
                    host.Opened += new EventHandler(host_Opened);
                    host.Faulted += new EventHandler(host_Faulted);
                    host.Open();
               // etc.
