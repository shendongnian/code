    string connStr = "connection string here";
    string sqlStatement = "select name from userdetails where emailid=@email";
    using (MySqlConnection conn = new MySqlConnection(connStr))
    {
    	using(MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = sqlStatement;
    		comm.CommandType = CommandType.Text;
    		
    		comm.Parameters.AddWithValue("@email", email);
    		
    		try
    		{
    			conn.Open();
    			MySqlDataReader rd = cmd.ExecuteReader();
    			// other codes
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
