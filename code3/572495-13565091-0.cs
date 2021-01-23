      public class SettingsService
        {
    
            private readonly ApplicationDataContainer _container;
    
            public SettingsService()
            {
                var localSettings = ApplicationData.Current.LocalSettings;
    
                if (!localSettings.Containers.ContainsKey("AppSettings"))
                {
                    _container = localSettings.CreateContainer("AppSettings", ApplicationDataCreateDisposition.Always);
                }
                else
                {
                    _container = localSettings.Containers["AppSettings"];
                }
            }
    
         private T GetValue<T>(string key, T @default)
            {
   
                if (_container.Values.ContainsKey(key))
                {
                    return (T)_container.Values[key];
                }
    
                return @default;
            }
    
            private void SetValue(string key, object value)
            {
                if (!_container.Values.ContainsKey(key))
                {
                    _container.Values.Add(key, value);
                }
                else
                {
                    _container.Values[key] = value;
                }
    
            }
           //Any setting
       public bool IsFirstLaunch
        {
            get { return GetValue("IsFirstLaunch", true); }
            set { SetValue("IsFirstLaunch", value); }
        }
    }
