    private static IProvider GetProviderFromConfig()
    {
        string typeName =
            ConfigurationManager.AppSettings["provider"];
        Type providerType = Type.GetType(typeName);
        
        return (IProvider)
            Activator.CreateInstance(providerType);
    }
