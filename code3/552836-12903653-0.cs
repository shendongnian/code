    public class CustomConfigConfigurationSection : ConfigurationSection
    {
        public static CustomConfigConfigurationSection Section
        {
            get
            {
                return ConfigurationManager.GetSection("customConfig") as CustomConfigConfigurationSection;
            }
        }
        public ConfigConfigurationElementCollection ConfigRoot
        {
            get
            {
                return this["configRoot"] as ConfigConfigurationElementCollection;
            }
        }
    }
    public class ConfigConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("key")]
        public string Key
        {
            get
            {
                return (string)this["key"];
            }
        }
        [ConfigurationProperty("value")]
        public string Value
        {
            get
            {
                return (string)this["value"];
            }
        }
    }
    public class ConfigConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigConfigurationElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigConfigurationElement)element).Key;
        }
    }
