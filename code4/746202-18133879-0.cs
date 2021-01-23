    using (var cmd = new SqlCommand())
    {
    		cmd.CommandText = "Your Query"
    		cmd.Connection = GetOpenDataConnection(".", "sampleDb", "sa", "12345");
    
    		//Execute NonQuery or ExecuteReader
            cmd.Connection.Close();
    }
    private SqlConnection GetOpenDataConnection(string server, string database, string user, string password)
    {
    	var builder = new SqlConnectionStringBuilder();
    	builder.DataSource = server;
    	builder.InitialCatalog = database;
 	    builder.UserID = user;
    	builder.Password = password;
    
    	var connection = new SqlConnection(builder.ToString());
    	connection.Open();
    	return connection;
    }
