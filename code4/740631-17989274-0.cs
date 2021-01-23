    namespace ConnectionHelper
    {
        public static class DBConnectionHelper
        {
            public static SqlConnection GetConnection()
           {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());
           }
        }
    }
