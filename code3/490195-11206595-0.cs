    //Outer Transaction        
    using (TransactionScope t = new TransactionScope())
    {
        	//Create persistence connection and command
        	// Execute persistence commands
        	//Inner scope to suppress the outer transaction
    	using (TransactionScope t1 = new TransactionScope(TransactionScopeOption.Suppress))
    	{
    		//create read connection
    		// Execute read operation
    	}
    	//continue with write operation
    }
