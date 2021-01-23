    public class MailConfiguration
        {
            private static string GetAppSetting(string key)
            {
                var element = ConfigurationManager.AppSettings["Mail:" + key];
                return element ?? string.Empty;
            }
    
            public static string BaseUrl => GetAppSetting("BaseUrl");     
    
            public static string Host => GetAppSetting("Host");
    
            public static int Port => Int32.Parse(GetAppSetting("Port"));
    
            public static string UserName => GetAppSetting("Username");
    
            public static string Password => GetAppSetting("Password");
    
            public static MailAddress From => new MailAddress(GetAppSetting("From"));
        }
	
