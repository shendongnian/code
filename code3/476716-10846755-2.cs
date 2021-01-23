    using System.Configuration;
    public static class AppSettingsGet
    {    
        public static string Username
        {
            get { return ConfigurationManager.AppSettings["username"].ToString(); }
        }
        public static string Password
        {
            get { return ConfigurationManager.AppSettings["password"].ToString(); }
        }
    }
