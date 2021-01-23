    private static log4net.ILog _logger;
    private static log4net.ILog Logger
    {
    	get
    	{
    		if( _logger == null )
    		{
    			Type type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
    			_logger = log4net.LogManager.GetLogger( type );
    		}
    		return _logger;
    	}
    }
