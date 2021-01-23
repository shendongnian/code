    public class ConfigSettings  
    {
        public static string ServerAddress
        {
            return System.Configuration.ConfigurationManager.AppSettings["ServerAddress"];
        }
        
        public static string OtherSetting
        {
            return System.Configuration.ConfigurationManager.AppSettings["OtherSetting"];
        }
    }
