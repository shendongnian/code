    IEnumerable<Task<SomeClass>> GetStuff()
    {
    	using (SqlConnection conn = new SqlConnection(""))
    	{
    		using (SqlCommand cmd = new SqlCommand("", conn))
    		{
    			conn.Open();
    			SqlDataReader reader = cmd.ExecuteReader();
    			while (true)
    				yield return ReadItem(reader);
    		}
    	}
    }
    
    async Task<SomeClass> ReadItem(SqlDataReader reader)
    {
    	if (await reader.ReadAsync())
    	{
    		// Create an instance of SomeClass based on row returned.
    		SomeClass someClass = null;
    		return someClass;
    	}
    	else
    		return null; // Mark end of sequence
    }
