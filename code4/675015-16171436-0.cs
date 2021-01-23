    private bool CheckDbConnection(string connectionString)
    {
    	try
    	{
    		using(var connection = new SqlConnection(connectionString))
    		{
    			connection.Open();
    			return true;
    		}
    	}
    	catch (Exception ex)
    	{
    		logger.Warn(LogTopicEnum.Agent, "Error in DB connection test on CheckDBConnection", ex);
    		return false; // any error is considered as db connection error for now
    	}
    }
