	int rowcount = 0;
	bool success = false;
	using (var connection = new SqlConnection("connectionString"))
	using (var command = new SqlCommand("SELECT TOP 10 * FROM Table"))
	{
		connection.Open();
		using (var reader = command.ExecuteReader())
		{
			success = reader.HasRows;
			while (reader.Read())
			{
				rowcount++;
				// DO SOMETHING WITH YOUR DATA
			}
		}
	}
	
	
