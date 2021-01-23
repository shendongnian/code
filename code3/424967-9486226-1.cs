    public class Configuration: IConfiguration
    {
        public User
        {
            get{ 
                   return ConfigurationManager.AppSetting["User"];
           }
        }
    }
