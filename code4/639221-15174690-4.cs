    public static class SqlConnectionUtil
    {
    	public static string DefaultConnectionString { get; private set; }
    	
    	static SqlConnectionUtil()
    	{
    		SqlConnectionUril.DefaultConnectionString = 
                    Properties.Settings.Default.TheConnectionString;
    	}
    
    	public static SqlConnection Create()
    	{
    		return new SqlConnection(this.DefaultConnectionString);
    	}
    }
    
