    if (Monitor.TryEnter(_lock))
    {
    	try
    	{
    		... await MyMethodAsync(); ...
    	}
    	finally
    	{
    		Monitor.Exit(_lock);
    	}
    }
