    using(var connection = new MySQLConnection(connectionString))
    {
    	using(var command = connection.CreateCommand())
    	{
    		command.CommandText = @"
    SELECT COUNT(*) 
    FROM users
    WHERE username = @user AND password = @password";
    		command.Parameters.Add(new MySQLParameter("user", user));
    		command.Parameters.Add(new MySQLParameter("password", password));
    		
    		var total = (int)command.ExecuteScalar();
    		if(total == )
    			InvalidLogin = true;
    		else
    			InvalidLogin = false;
    	}
    }
