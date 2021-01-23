    DataTable GetDataTableScheme(string tableName)
    {
    	var table = new DataTable();
    
    	using (var connection = new MySqlConnection(*[ConnectionString]*))
    	using (var dataAdapter = new MySqlDataAdapter($"SELECT * FROM {tableName} WHERE FALSE", connection))
    	{
    		// Adds additional info, like auto-increment
    		dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    
    		dataAdapter.Fill(table);
    	}
    
    	return table;
    }
