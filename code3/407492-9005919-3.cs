    ...
    using (var ta = conn.BeginTransaction(IsolationLevel.Snapshot))
    {
        IDbCommand command = conn.CreateCommand("SELECT * from stock;");
        command.SetTransaction(ta);
        IDataReader reader = command.ExecuteReader();
    
        int n = 5000;
    	
    	//put it in using
    	using(IDataReader reader = command.ExecuteReader())
    	{
    		//read first N rows
    		for(int i=0;i<n;i++)
    		{			
    			//get value from the columns of the current row
    			for (i = 0; i < reader.FieldCount; i++)
    			{
    				Console.Write("{0} \t", reader[i]);
    			}
    		}
    	}    
    }
