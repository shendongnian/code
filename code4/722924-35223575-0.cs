    string ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
    
    
            using (var sqlConnection = new SqlConnection(ConnectionString ))
            {
                var result= sqlConnection.Query<My_Class>("MY_PROC_NAME", new { count }, commandType: CommandType.StoredProcedure);
                return result;
            }
