    public void BeginExecutingCommands(Report someReport)
    {
        foreach (record someRecord in someReport.r)	
        {
            var command = new SqlCommand("[procname]", sqlConn);
            command.CommandTimeout = 0;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(…);
		
            command.BeginExecuteReader(ReaderExecuted, 
                new object[] { command, someReport, someRecord });					 
        }
    }
    void ReaderExecuted(IAsyncResult result)
    {
        var state = (object[])result.AsyncState;
        var command = state[0] as SqlCommand;
        var someReport = state[1] as Report;
        var someRecord = state[2] as Record;
	
        try
        {
            using (SqlDataReader reader = command.EndExecuteReader(result))
            {
                // work with reader, command, someReport and someRecord to do what you need.
            }
        }
        catch (Exception ex)
        {
            // handle exceptions that occurred during the async operation here
        }
    }
