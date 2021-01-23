    private static void SubmitData(string firstName, string lastName)
    {
    	using (var connection = new SqlConnection("your connection string"))
    	{
    		connection.Open();
    
    		using (var command = connection.CreateCommand())
    		{
    			command.CommandType = CommandType.StoredProcedure;
    			command.CommandText = "submitdata";
    
    			command.Parameters.AddWithValue("@FirstName", firstName);
    			command.Parameters.AddWithValue("@LastName", lastName);
    
    			command.ExecuteNonQuery();
    		}
    	}
    }
