        public class Configuration : IConfiguration
        {
            public string MyConnectionString
            {
                get { return ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["myConnection"]].ConnectionString; }
            }
        }
