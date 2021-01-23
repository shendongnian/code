    /// Create the ServiceHost.
    using (ServiceHost host = new ServiceHost(typeof(NEN), baseAddress)) {
        /// Enable metadata publishing.
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
        host.Description.Behaviors.Add(smb);
    // Add MEX endpoint
      host.AddServiceEndpoint(
      ServiceMetadataBehavior.MexContractName,
      MetadataExchangeBindings.CreateMexHttpBinding(),
      "mex");
