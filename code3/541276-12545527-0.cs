    public class ConfigurationManager
    {
        private ObservableCollection<IConfigList<BaseConfig>> _configItems;
        public ConfigurationManager()
        {
            _configItems = new ObservableCollection<IConfigList<BaseConfig>>();
        }
        public void AddConfigList(IConfigList<BaseConfig> configList)
        {
            _configItems.Add(configList);
        }
    }
