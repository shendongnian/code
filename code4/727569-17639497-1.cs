    private readonly object writeLock = new object ();
    private static Lazy<IDictionary<string, IAuthenticationProvider>> _authenticationProviders;
    private static bool _hasParsedConfigFile = false;
    public static IDictionary<string, IAuthenticationProvider> AuthenticationProviders
    {
        get { return new Lazy<IDictionary<string, IAuthenticationProvider>>(
                () =>
                {
                    var authenticationProviders =
                        new Dictionary
                            <string, IAuthenticationProvider>();
    
                    if (!_hasParsedConfigFile)
                    {
                        lock(writeLock)
                        {
                             Initialize();
                             _hasParsedConfigFile = true;
                        }
                    }
    
                    return authenticationProviders;
                });  }
    }
