    string connStr = "connection string here";
    string query = @"SELECT ... 
    				FROM... 
    				WHERE STR_TO_DATE(d.despdate, '%d-%b-%Y') BETWEEN @date1 AND @date2"
    using(MySqlConnection _conn = new MySqlConnection(connStr))
    {
    	using (MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = query;
    		comm.Parameters.AddWithValue("@date1", dTime1.Value);
    		comm.Parameters.AddWithValue("@date2", dTime2.Value);
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(MySqlException e)
    		{
    			// do something with
    			// e.ToString()
    		}
    	}
    }
