    class LogUtil<T> : ILogUtility
    {
    	log4net.ILog log;
    
    	public LogUtil(object classtype)
    	{
    		log = log4net.LogManager.GetLogger(typeof(T).FullName);
    	}
    
    	public void Log(LogType logtype, string message)
    	{
    		Console.WriteLine("logging coming from class {0} - message {1}", typeof(T).FullName, message);
    	}
    }
