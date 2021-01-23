    string content = comboBoxPlayer.Text;
    string connStr = "connection string here";
    string sqlCommand = @"SELECT   *
                          FROM     tblMatches 
                          WHERE matchPlayerNick = @content
                          ORDER BY matchName";
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
    			// other codes here
    		}
    		catch(SqlException e)
    		{
    			// do something with the exception
    			// do not hide it
    			// e.Message.ToString()
    		}
    	}
    }
