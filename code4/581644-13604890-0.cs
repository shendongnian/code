    public string CreateEntry(string connectionString, string valueToInsert)
    {
    	var stringToReturn = "";
    	
    	try
    	{
    		using(var connection = new MySqlConnection(connectionString))
    		{
    			//Open connection
    			connection.Open();
    			
    			//Compose query using sql parameters
    			var sqlCommand = "INSERT INTO table_name (field_name) VALUES (@valueToInsert)";
    			
    			//Create mysql command and pass sql query
    			using(var command = new MySqlCommand(sqlCommand, connection))
    			{
    				command.Parameters.AddWithValue("@valueToInsert", valueToInsert);
    				command.ExecuteNonQuery();
    			}			
    			
    			stringToReturn ="Success Message";
    		}
    	}
    	catch(exception ex)
    	{
    		stringToReturn = "Error Message: " + ex.Message;
    	}
    	
    	return stringToReturn;
    }
