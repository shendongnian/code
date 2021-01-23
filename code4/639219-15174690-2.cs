    public static class SqlConnectionUtil
    {
    	public static string DefaultConnectionString { get; private set; }
    	
    	public static SqlConnectionUtil()
    	{
    		// set SqlConnectionExtensions.DefaultConnectionString here
    	}
    
    	public static SqlConnection Create()
    	{
    		return new SqlConnection(this.DefaultConnectionString);
    	}
    }
    
