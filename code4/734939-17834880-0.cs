    // Simple static example
    public static class DatabaseConnection
    {
    	public static IDBConnection ActiveConnection {get; private set;}
    	
    	static DatabaseConnection()
    	{
    		var myConnectionString = // get your connection string;
    		ActiveConnection = new SqlConnection(myConnectionString);
    		ActiveConnection.Connect(); // This is bad, really should be in a using
    	}
    }
    
    // Simple static usage
    DatabaseConnection.ActiveConnection.ExecuteQuery(blah);
