    // Better static example using actions
    public static class DatabaseConnection
    {
    	private static string connectionString;
    
    	public static void OpenConnectionAnd(Action<Connection> actionToDo)
    	{
    		using(var connection = new SqlConnection(this.connectionString))
    		{
    			connection.Connect();
    			actionToDo.Invoke(connection);
    			connection.Disconnect();
    		}		
    	}
    	
    	static DatabaseConnection()
    	{
    		this.connectionString = // get your connection string;
    	}
    }
    
    // Better usage example
    DatabaseConnection.OpenConnectionAnd(x => x.Execute(blah));
