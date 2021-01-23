    public class MyConfigurationSection : System.Configuration.ConfigurationSection
    {
        [ConfigurationProperty("myProperty")]
        public string MyProperty 
        {
            get { return (string)this["myProperty"]; }
            set { this["myProperty"] = value; }
        }
    }
