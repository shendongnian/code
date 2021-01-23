    public abstract class ConfigurationManager
    {
        public abstract string GetKeyValueSetting(string key);
    
        public static ConfigurationManager GetInstance()
        {
             return GetInstance(GetDefaultSettingProvider(), GetDefaultProviderFactory());
        }
    
        public static ConfigurationManager GetInstance(ISettingsProvider provider, IProviderFactory factory)
        {
             return new InternallyVisibleConfigurationManagerImplementation(provider, factory);
        }
    }
