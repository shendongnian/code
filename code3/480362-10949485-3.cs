    class SomeConfigurationConfigurationSections : ConfigurationSection, ISomeConfiguration
    {
        [ConfigurationProperty("SomeValue")]
        public int SomeValue
        {
            get { return (int)this["SomeValue"]; }
        }
    
        [ConfigurationProperty("AnotherValue")]
        public string AnotherValue
        {
            get { return (string)this["AnotherValue"]; }
        }
    }
