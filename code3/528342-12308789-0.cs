    try
    {
    	// Stuff
    }
    catch (Exception exc)
    {
    	if (exc.InnerException is System.Data.SqlClient.SqlException)
    	{
    		var sqlException = exc.InnerException as System.Data.SqlClient.SqlException;
    		
    		// Do stuff with the error.
    	}
    }
