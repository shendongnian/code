    async Task<IEnumerable<SomeClass>> GetStuff()
    {
    	using (SqlConnection conn = new SqlConnection(""))
    	{
    		using (SqlCommand cmd = new SqlCommand("", conn))
    		{
    			await conn.OpenAsync();
    			SqlDataReader reader = await cmd.ExecuteReaderAsync();
    			return ReadItems(reader).ToArray();
    		}
    	}
    }
    
    IEnumerable<SomeClass> ReadItems(SqlDataReader reader)
    {
    	while (reader.Read())
    	{
    		// Create an instance of SomeClass based on row returned.
    		SomeClass someClass = null;
    		yield return someClass;
    	}
    }
