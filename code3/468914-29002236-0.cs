    public Interface ICredentialConfig
    {
       string Username { get; }
       string Password { get; }
    }
    public Interface IConfig : ICredentialConfig
    {
       //... other settings
    }
