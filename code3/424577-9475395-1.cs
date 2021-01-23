    public class ConfigSettings  
    {
        public static string ServerAddress
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ServerAddress"];
            }
        }
        
        public static string OtherSetting
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["OtherSetting"];
            }
        }
    }
