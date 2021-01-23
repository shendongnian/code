    try
    {
        using (var command = new SqlCommand("[procname]", sqlConn))
        {
            command.CommandTimeout = 0;
            command.CommandType = CommandType.StoredProcedure;
    
            foreach (record someredord Somereport.r)
    	    {
    	        command.Parameters.Clear()
                command.Parameters.Add(…);
    			
                using (var rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        …
                    }
                }
    	    }
    	}
    }
    catch (…)
    {
        …
    }
