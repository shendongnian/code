    BaseAddress = new Uri(args[0]);
    using (ServiceHost host = new ServiceHost(typeof(Namespace.Classname), BaseAddress))
    {
      ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
      smb.HttpGetEnabled = true;
      smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
      host.Description.Behaviors.Add(smb);
      host.AddServiceEndpoint(typeof(Namespace.IInterface), new BasicHttpBinding(), args[0]);
      host.Open();
