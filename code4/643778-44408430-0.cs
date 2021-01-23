    Task[] tasks = new Task[1000];
    for (int i = 0; i < 1000; i++)
    {
    	int j = i;
    	tasks[i] = new Task(() =>
    		 ExecuteSqlTransaction("YourConnectionString", j)
    		);
    }
    
    foreach (Task task in tasks)
    {
    	task.Start();
    }       
    /////////////    
    public static void ExecuteSqlTransaction(string connectionString, int exeSqlCou)
    {
    	
    	using (SqlConnection connection = new SqlConnection(connectionString))
    	{
    		connection.Open();
    
    		SqlCommand command = connection.CreateCommand();
    		SqlTransaction transaction;
    
    		// Start a local transaction.
    		transaction = connection.BeginTransaction("SampleTransaction");
    
    		// Must assign both transaction object and connection
    		// to Command object for a pending local transaction
    		command.Connection = connection;
    		command.Transaction = transaction;
    
    		try
    		{
    			command.CommandText =
    				"select * from Employee";
    			command.ExecuteNonQuery();
    
    			// Attempt to commit the transaction.
    			transaction.Commit();
    
    			Console.WriteLine("Execute Sql to database."
    				+ exeSqlCou);
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
    			Console.WriteLine("  Message: {0}", ex.Message);
    
    
    			// Attempt to roll back the transaction.
    			try
    			{
    				transaction.Rollback();
    			}
    			catch (Exception ex2)
    			{
    				// This catch block will handle any errors that may have occurred
    				// on the server that would cause the rollback to fail, such as
    				// a closed connection.
    				Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
    				Console.WriteLine("  Message: {0}", ex2.Message);
    
    			}
    		}
    	}
    }
