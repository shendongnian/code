	public void InsertPath(string path)
	{
		string connString = "Server=Localhost;Database=test;Uid=root;password=root;";
	
	    using (var connection = new MySqlConnection(connString))
		{
			connection.Open();
			
			using (var command = connection.CreateCommand())
			{
				command.CommandText = "INSERT INTO data(path) VALUES(?path)";
				
				command.Parameters.AddWithValue("?path", path);
				
				command.ExecuteNonQuery();
			}
		}
	}
