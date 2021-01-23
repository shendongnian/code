    string content = TeamSyncKey;
    string connStr = "connection string here";
    string sqlStatement = "INSERT INTO jt_teamsync (`key`) VALUES (@key)";
    using (MySqlConnection conn = new MySqlConnection(connStr))
    {
    	using(MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = sqlStatement;
    		comm.CommandType = CommandType.Text;
    		
    		comm.Parameters.AddWithValue("@key", content);
    		
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(MySqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
