    public static DataTable GetSqlData(string sql)
    {
        // get Connectionstring from app.config 
        string connStr = System.Configuration.ConfigurationManager.AppSettings["YourConnection"];
        using (SqlConnection myConnection = new SqlConnection(connStr))
        {
            myConnection.Open();
            DataTable dt = new DataTable();
            using (var command = new SqlCommand())
            {
                command.Connection = myConnection;
                command.CommandText = sql;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);                                        
                dt.Load(reader);
            }
            return dt;
        }            
    }// End of GetSqlData
