    public class AppConfigProvider
    {
        public AppConfigProvider()
        {
            ConnectionStrings = new ConnectionStringsProvider();
            AppSettings = new AppSettingsProvider();
        }
    
        public ConnectionStringsProvider ConnectionStrings { get; private set; }
    
        public AppSettingsProvider AppSettings { get; private set; }
    }
    
    public class ConnectionStringsProvider
    {
        private readonly Dictionary<string, string> _customValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    
        public string this[string key]
        {
            get
            {
                string customValue;
                if (_customValues.TryGetValue(key, out customValue))
                {
                    return customValue;
                }
    
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[key];
                return connectionStringSettings == null ? null : connectionStringSettings.ConnectionString;
            }
        }
    
        public Dictionary<string, string> CustomValues { get { return _customValues; } }
    }
    
    public class AppSettingsProvider
    {
        private readonly Dictionary<string, string> _customValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    
        public string this[string key]
        {
            get
            {
                string customValue;
                return _customValues.TryGetValue(key, out customValue) ? customValue : ConfigurationManager.AppSettings[key];
            }
        }
    
        public Dictionary<string, string> CustomValues { get { return _customValues; } }
    }
