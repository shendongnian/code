    internal class Configuration
    {
    	public static string ApplicationName
    	{
    		get
    		{
    			return ConfigurationManager.AppSettings["ApplicationName"];
    		}
    	}
    }
