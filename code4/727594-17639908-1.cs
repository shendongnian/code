    public class dbconnection
    {
    	MySqlConnection connection;
    	int flag = 0;
    
    	public int Flag
    	{
    		get { return flag; }    
    	}
    	
    	public MySqlConnection Connection
    	{
    		get { return this.connection; }
    	}
    
    	public dbconnection()
    	{
    		this.connection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mysqlconnect"].ConnectionString);
    
    		try
    		{
    			this.connection.Open();
    			flag = 1;
    		}    
    		catch (Exception e)
    		{
    			flag = 0;
    			MessageBox.Show(e.Message );    
    		}               
       }    
    }
