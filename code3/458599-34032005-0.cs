    using System.Transactions;
        // _sqlConnection has been opened elsewhere in preceeding code 
        using (var transactionScope = new TransactionScope())
        {
        	try
        	{
        		long result = _sqlConnection.ExecuteScalar<long>(sqlString, new {Param1 = 1, Param2 = "string"});
        		
        		transactionScope.Complete();
        	}
        	catch (Exception exception)
        	{
        		transactionScope.Dispose();
        		// Log that something unexpected happened
        		
        		// re-throw to let the caller know
        		throw;
        	}
        }
