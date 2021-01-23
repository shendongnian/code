    string connStr = "connection string here";
    string content = string.Format("{0}{1}{0}", "%", identifier);
    string sqlStatement = "SELECT [identifier] FROM [information] WHERE [identifier] LIKE ?";
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
