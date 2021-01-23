    public class GlobalInfo
    {
    	public static string ConnectionString { get; set; }
    	
    	//Method to use ti update your connectionString
    	public static void UpdateConnectionString(string databaseName)
    	{
            ConnectionString = "Build your connection string";
    	}
    }
    
    
    public class MyController()
    {
        //Method using your connection string
    	public void MyMethod()
    	{
    		using(var connection = new SqlConnection(GlobalInfo.ConnectionString))
    		{
    			connection.Open();
    			//The rest of your code
    		}
    	}
    }
