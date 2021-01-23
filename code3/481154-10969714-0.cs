    public T AppConfig
    {
        get
        {
            if (appConfig == null)
            {
               return ReloadConfiguration();
            }
            return appConfig;
        }
    }
