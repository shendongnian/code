    class SomeThingDependentOnSomeConfiguration
    {
        public SomeThingDependentOnSomeConfiguration(ISomeConfiguration config) { ... }
    }
    
    interface ISomeConfiguration
    {
        int SomeValue { get; }
        string AnotherValue { get; }
    }
    
    class SomeConfigurationAppSettings : ISomeConfiguration
    {
        public int SomeValue
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["SomeValue"]);
            }
        }
    
        public string AnotherValue
        {
            get
            {
                return ConfigurationManager.AppSettings["AnotherValue"];
            }
        }
    }
