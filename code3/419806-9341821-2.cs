    using(var connection = new MySqlConnection(ConfigurationManager.AppSettings["connectionString"]))
    {
    	connection.Open();
    	using(var command = connection.CreateCommand())
    	{
    		command.CommandText = "INSERT INTO uploadeddata VALUES (@id, @filename, @serverKey, @token, @userId)";
    		command.Parameters.Add(new MySqlParameter("id", 0));
    		command.Parameters.Add(new MySqlParameter("filename", fileName));
    		command.Parameters.Add(new MySqlParameter("serverKey", id));
    		command.Parameters.Add(new MySqlParameter("token", strTokens));
    		command.Parameters.Add(new MySqlParameter("userId", Session["LoggedInUserId"]));
    		
    		command.ExecuteNonQuery();
    	}
    }
