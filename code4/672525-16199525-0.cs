    public DataSet FetchDataSet(string sql, IDictionary paramHash) {
    	var cnn = AcquireConnection();
    	var rtnDS = new DataSet();
    	try
    	{
    		var cmd = cnn.CreateCommand();
    		cmd.CommandText = sql;
    
    		SetParameters(cmd, paramHash);
    		IDbDataAdapter ida = new DataAdapter { SelectCommand = cmd };
    		LogSql(sql, paramHash, "FetchDataSet");
    		ida.Fill(rtnDS);
    	}
    	catch (Exception ex)
    	{
    		DebugWriteLn("Failed to get a value from the db.", ex);
    		throw;
    	}
    	finally
    	{
    		ReleaseConnection(cnn);
    	}
    	return rtnDS;
    }
