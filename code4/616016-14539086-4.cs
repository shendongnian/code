    public static ConfigurationManager GetInstance()
    {
         return GetInstance(GetAppropriateProvider(), GetDefaultProviderFactory());
    }
    private static ISettingsProvider GetAppropriateProvider()
    {
         if(ShouldUseSharepoint())
              return OrderedCompositeSettingProvider.GetInstance(new SharepointProvider(), new StoredSettingsProvider());
         
         return OrderedCompositeSettingProvider.GetInstance(new ConfigFileProvider(), new StoredSettingsProvider());
    }
