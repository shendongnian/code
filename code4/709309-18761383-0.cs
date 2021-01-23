    public Fusion()
    {
        // Create the service.
        objService = new FusiontablesService(new BaseClientService.Initializer()
        {
            Authenticator = CreateAuthenticator()
        });
        objService.Authenticator.LoadAccessToken();
    }
