    public abstract class Data
    {
    	[...]
    	static Data()
    	{
    		#if DEBUG
    			_Connection = ConfigurationManager.AppSettings["debug"];
    		#endif
    
    		#if RELEASE
    			_Connection = ConfigurationManager.AppSettings["release"];
    		#endif
    		[...]
    	}
    	[...]
    }
