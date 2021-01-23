    query = "select count(*) from table where name = @name";
    string connString =ConfigurationManager.ConnectionStrings["mydb"].ToString();
    using(MySqlConnection connection = new MySqlConnection(connString))
    {
    	using(MySqlCommand command = new MySqlCommand(query, connection))
    	{
    		command.Parameters.Add("@name", name);
    		try
    		{
    			connection.Open();
    			// other codes
    		}
    		catch(MySqlException ex)
    		{
    			// do somthing with the exception
    			// don't hide it
    		}
    	}
    }
