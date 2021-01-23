    public static BaseClientService.Initializer BuildServiceInitializer(string privateKeyPath, string serviceAccountEmail, string scope, string applicationName)
        {
            X509Certificate2 certificate = new X509Certificate2(privateKeyPath, "notasecret",
                X509KeyStorageFlags.Exportable);
    
            var provider = new AssertionFlowClient(GoogleAuthenticationServer.Description, certificate)
            {
                ServiceAccountId = serviceAccountEmail,
                Scope = scope
            };
            var auth = new OAuth2Authenticator<AssertionFlowClient>(provider, AssertionFlowClient.GetState);
            return new BaseClientService.Initializer()
            {
                Authenticator = auth,
                ApplicationName = applicationName
            };
        }
