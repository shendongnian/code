    internal class OrderedCompositeSettingProvider : ISettingProvider
    {
        private readonly ISettingProvider[] _providers;
    
        private OrderedCompositeSettingProvider(ISettingProvider[] providers)
        {
            _providers = providers;
        }
    
        internal static ISettingProvider GetInstance(params ISettingProvider[] providers)
        {
             return new OrderedCompositeSettingProvider(providers)
        }
    
        public string GetKeyValueSetting(string key)
        {
            foreach(var provider in _providers)
            {
                 var setting = provider.GetKeyValueSetting(key);
                 if(!string.IsNullOrEmpty(setting)) return setting;
            }
            return string.empty;
        }
    
    }
