    string mysqlStatement = @"INSERT INTO test1(Paper, Authors, ID, GSCitations) 
    							VALUES(@paper, @Authors, @ID, @GSCitations)";
    
    MySqlCommand mysqlCmd = new MySqlCommand(mysqlStatement, connection);
    mysqlCmd.ExecuteNonQuery();
    
    string connStr = "connection string here";
    using (MySqlConnection conn = new MySqlConnection(connStr))
    {
    	using (MySqlCommand comm = new MySqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = mysqlStatement;
    		comm.Parameters.AddWithValue("@paper", row.Cells[0].Value);
    		comm.Parameters.AddWithValue("@Authors", row.Cells[1].Value);
    		comm.Parameters.AddWithValue("@ID", row.Cells[2].Value);
    		comm.Parameters.AddWithValue("@GSCitations", row.Cells[3].Value);
    		try
    		{
    			conn.Open();
    			comm.ExcuteNonQuery();
    		}
    		catch(MySqlException e)
    		{
    			// do something with
    			// e.ToString()  // this is the exception
    		}
    	}
    }
