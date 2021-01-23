    public static class sqlConnectionProvider
        {
            public static string GetConnection()
            {
                return ConfigurationManager.ConnectionStrings["StrConnection"].ConnectionString;
            }
    
        }
