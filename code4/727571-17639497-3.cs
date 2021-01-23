        private readonly object writeLock = new object();
        private static Lazy<IDictionary<string, IAuthenticationProvider>> _authenticationProviders;
        private static bool _hasParsedConfigFile = false;
        public static IDictionary<string, IAuthenticationProvider> AuthenticationProviders
        {
            get
            {
                if (!_hasParsedConfigFile)
                {
                    lock (writeLock)
                    {
                        if (!_hasParsedConfigFile)
                        {
                            _authenticationProviders = new Dictionary<string, IAuthenticationProvider>();
                            Initialize();
                            _hasParsedConfigFile = true;
                        }
                    }
                }
                return _authenticationProviders;
            }
        }
