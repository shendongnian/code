    string connStr = "connection string here";
    string sqlStatement = "INSERT INTO tableName (content) VALUES (@content)";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using(SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = sqlStatement;
    		comm.CommandType = CommandType.Text;
    		
    		comm.Parameters.AddWithValue("@content", content);
    		
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
