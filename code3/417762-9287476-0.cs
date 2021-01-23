    static public bool IsConnectionAlive(string connectionString)
    {
    	try
    	{
    		using (SqlConnection conn = new SqlConnection(connectionString))
    		{
    			conn.Open();
    			using (SqlCommand cmd = new SqlCommand("SELECT 1", conn))
    			{
    				int result = (int)cmd.ExecuteScalar();
    				return (result == 1);
    			}
    			
    		}
    	}
    	catch (Exception ex)
    	{
    		// You need to decide what to do here... e.g. does a malformed connection string mean the "connection isn't alive"?
    		// Maybe return false, maybe log the error and re-throw the exception?
    		throw;
    	}
    }
