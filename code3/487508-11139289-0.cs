    class Connection
        {
            public static string con
            {
                get
                {
                    return System.Configuration.ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
                }
            }
        }
