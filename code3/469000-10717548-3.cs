    var binding = new WS2007FederationHttpBinding(WSFederationHttpSecurityMode.Message);
    
    var factory = new ChannelFactory<IYourInterface >(binding, "your service address");
    
    factory.ConfigureChannelFactory();
    
    IYourInterface channel = factory.CreateChannelWithIssuedToken(token);
