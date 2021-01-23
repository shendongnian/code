    //Store the authentication description
    AuthorizationServerDescription desc = GoogleAuthenticationServer.Description;
    //Create a certificate object to use when authenticating
    var rsaCryptoServiceProvider = new RSACryptoServiceProvider();
    rsaCryptoServiceProvider.FromXmlString(File.ReadAllText(keyFile));
    var key = new X509Certificate2(certFile) {PrivateKey = rsaCryptoServiceProvider};
    //Now, we will log in and authenticate, passing in the description
    //and key from above, then setting the accountId and scope
    var client = new AssertionFlowClient(desc, key)
    {
        ServiceAccountId = clientId,
        Scope = scope
    };
    //Finally, complete the authentication process
    //NOTE: This is the first change from the update above
    var auth = new OAuth2Authenticator<AssertionFlowClient>(client, AssertionFlowClient.GetState);
    //First, create a new service object
    //NOTE: this is the second change from the update
    //above. Thanks to James for pointing this out
    var gas = new AnalyticsService(new BaseClientService.Initializer { Authenticator = auth });
