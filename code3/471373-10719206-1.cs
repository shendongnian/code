    class SQLconnect
    {
        public static void Sql(string Command_Text, params SqlParameter[] parameters)
        {
            string connectionPath =
                "Data Source=USER\\SQLEXPRESS;Initial Catalog=db;Integrated Security=SSPI;";
    
            SqlConnection Connection = new SqlConnection(connectionPath);
    
            Connection.Open();
    
            SqlCommand Command = Connection.CreateCommand();
            Command.CommandText = Command_Text;
    
            if(parameters != null && parameters.Length > 0) 
            {
              foreach(var p in parameters)
                Command.Parameters.Add(p);
            }
    
    
            Command.ExecuteNonQuery();
    
            Connection.Close();
        }
    }
