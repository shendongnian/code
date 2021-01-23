    public class AspNetHostDatabaseConnectionFactory 
        : IConnectionFactory
    {
        public SqlConnection OpenConnection()
        {
            string connStr = GetConnectionString();
        
            var connection = new SqlConnection(connStr);
            
            connection.Open();
            
            return connection;
        }
        
        // This is the old code from your OnActionExecuting method.
        private static string GetConnectionString()
        {
            var database = String.Empty;
            
            switch (HttpContext.Current.Request.Url.Host)
            {
                case "aaa.domain.local":
                    database = "AAA";
                    break;
                case "bbb.domain.local":
                    database = "BBB";
                    break;
                case "ccc.domain.local":
                    database = "CCC";
                    break;
            }
            return WebConfigurationManager
                .ConnectionStrings[database].ConnectionString;
        }
    }
