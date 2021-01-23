		//Here is the connection strings with IP, Login, and DBname from web.config You need to configure it dynamicaly
        private string PostgreSQLConnection = WebConfigurationManager.ConnectionStrings["PostgreSQLConnection"].ConnectionString;
        private string OracleConnection = WebConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
              
        using (PostgreSQLExecutor executor = new PostgreSQLExecutor(PostgreSQLConnection))
        {
            executor.ExecuteQuery(@"query");
        }
        using (OracleSQLExecutor executor = new OracleSQLExecutor(OracleConnection))
        {
            executor.ExecuteQuery(@"query");
        }
		
