    using (var connection = new SqlConnection(@"Server=(localdb)\v11.0;Database=MyDatabaseName;Integrated Security=true;")
    {
    	connection.Open();
    
    	using (var command = connection.CreateCommand())
    	{
            	command.CommandText = "INSERT INTO [Main] ([Cable Length1], [Cable Length2]) VALUES(@3, @5)";
    
            	command.Parameters.AddWithValue("@3", 1);
            	command.Parameters.AddWithValue("@5", 2);
    
            	command.ExecuteNonQuery();
    	}
    }
