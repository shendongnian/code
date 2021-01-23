    using(SqlDbConnection connection = new SqlDbConnection("your_connection_string"))
    {
    	using(SqlDbCommand command = new SqlDbCommand(query))
    	{
    	  command.CommandType = CommandType.Text;
    	  command.Connection = connection;
    	  command.Parameters.AddWithValue("@read", Read);
    	  command.Parameters.AddWithValue("@ertnumber", rtNumber);
    	  command.Parameters.AddWithValue("@date", DateStamp);
    	  
          connection.Open();
    		
    	  command.ExecuteNonQuery();
    	
    	}
    
    }
