    public int UpdateSQLDataTable(string connectionString, string TableName, DataTable dtSource)
    {
    	using (SqlConnection sConn = new SqlConnection(connectionString))
    	{
    		sConn.Open();
    
    		var transaction = sConn.BeginTransaction();
    
    		try
    		{
    			SqlCommand command = sConn.CreateCommand();
    			command.Transaction = transaction;
    
    			command.CommandText = string.Format("SELECT TOP 1 * FROM dbo.[{0}] WITH (NOLOCK)", TableName);
    			command.CommandType = CommandType.Text;
    			
    			// timeout in seconds...
    			command.CommandTimeout = 30;
    
    			SqlDataAdapter sAdp = new SqlDataAdapter(command);
    
    			SqlCommandBuilder sCMDB = new SqlCommandBuilder(sAdp);
    
    			int affectedRecords = sAdp.Update(dtSource);
    
    			transaction.Commit();
    
    			return affectedRecords;
    		}
    		catch (Exception /* exp */)
    		{
    			transaction.Rollback();
    
    			throw;
    		}
    	}
    }
