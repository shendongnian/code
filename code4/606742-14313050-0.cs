    namespace dm2
    {
        using System.Collections.Specialized;
        using System.Configuration;
    
        public class SomeApiClient
        {
            internal static NameValueCollection Config
            {
                get
                {
                    if (config == null) config = ConfigurationManager.AppSettings;
                    return config;
                }
            }
    
            internal static NameValueCollection config;
        }
    }
