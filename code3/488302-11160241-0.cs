    var connection = new MySqlConnection(connStr);
	
	try
	{
		connection.Open();
		
		var command = new MySqlCommand(
		    "SELECT * FROM tblCountry WHERE Name = @Name", connection);
		command.Parameters.AddWithValue("@Name", name);
		
		...
	}
	finally
	{
		connection.Close();
	}
