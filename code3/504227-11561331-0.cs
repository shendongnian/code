    public class LastAccessConfigurationSection : System.Configuration.ConfigurationSection {
        [ConfigurationProperty("LastAccess")]
        public string LastAccess{
            get { return (string)this["LaunchTime"]; }
            set { this["LaunchTime"] = value; }
        }
    }
