    public class Helper<T> where T : struct
    {
    	public T GetPlatformType()
    	{
    		string platform = System.Configuration.ConfigurationManager.AppSettings["Platform"];
    		T value;
    		if (Enum.TryParse(platform, out value))
    			return value;
    		else
    			return default(T); 	// or throw, or something else reasonable
    	}
    }
