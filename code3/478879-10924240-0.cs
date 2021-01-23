    if(Update(connection) == 0)
    {
    	using (var command = new SqlCommand(@"INSERT INTO foo VALUES (Bar, ...)", connection))
    	{
    		try
    		{	
    			command.ExecuteNonQuery(); 
    		}				
    		catch (BlahUniqueConstraintException) // dummy exception, please replace with relevant
    		{
    			// very rarely will get in here
    			Update(connection);
    		}			
    	}
    }			
    			
    private int Update(SqlConnection connection)
    {
    	// use update to do two things at once: find out if the record exists and also ... update
    	using (var command = new SqlCommand(@"UPDATE foo SET ... WHERE PropertyThatshouldBeUnique = 'Bar'", connection))
    	{
    		// if the record exists and is updated then returns 1, otherwise 0
    		return command.ExecuteNonQuery();
    	}	
    }
