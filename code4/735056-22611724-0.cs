    var exampleContractChannelFactory = new ChannelFactory<IExampleContract>("DiscoveryEndpoint");
    var exampleContractClient = exampleContractChannelFactory.CreateChannel();
    // You can now invoke methods on the exampleContractClient
    // The actual service endpoint used by the client will be looked up dynamically 
    // by the proxy using the DiscoveryClient class internally.
