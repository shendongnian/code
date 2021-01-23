    // Prepare WebOperationContext
    var factory = new ChannelFactory<IOauth2>(
        new WebHttpBinding(),
        new EndpointAddress("http://localhost:80"));
    OperationContext.Current = new OperationContext(factory.CreateChannel() as IContextChannel);
    Debug.Assert(WebOperationContext.Current != null);
