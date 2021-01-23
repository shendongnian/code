    public class MyConfiguration : ISomeConfiguration
    {
        readonly NameValueCollection settings = ConfigurationManager.AppSettings;
    
        public string SomeSettings
        {
            get { return settings["SomeSetting"]; }
        }
    }
