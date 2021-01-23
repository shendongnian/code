    //Create the connection
    using(SqlDbConnection connection = new SqlDbConnection("your_connection_string"))
    {
        //Create the Command
    	using(SqlDbCommand command = new SqlDbCommand(query))
    	{
          //Set up the properties of the command and the parameters
    	  command.CommandType = CommandType.Text;
    	  command.Connection = connection;
    	  command.Parameters.AddWithValue("@read", Read);
    	  command.Parameters.AddWithValue("@ertnumber", rtNumber);
    	  command.Parameters.AddWithValue("@date", DateStamp);
    	  //Have to open the connection before we do anything with it
          connection.Open();
    	  //Execute the command. As we don't need any results back we use ExecuteNonQuery	
    	  command.ExecuteNonQuery();
    	
    	}
    }//At this point, connection will be closed and disposed - you've cleaned up
