    WSTrustChannelFactory adfsfactory = new WSTrustChannelFactory(new UserNameWSTrustBinding(SecurityMode.TransportWithMessageCredential),
                                StsEndpoint);
    
    adfsfactory.TrustVersion = TrustVersion.WSTrust13;
    
    // Username and Password here...
    factory.Credentials.UserName.UserName = "domain\username";
    factory.Credentials.UserName.Password = "password";
    
    IWSTrustChannelContract channel = adfsfactory.CreateChannel();
    
    // request the token
    SecurityToken token = channel.Issue(rst);
