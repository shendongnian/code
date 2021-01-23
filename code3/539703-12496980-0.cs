	public static bool _isRunning = false;
	public static void StartJob() 
	{ 
	    ThreadPool.QueueUserWorkItem(s => { ProcessRows(); })
	} 
	public static void ProcessRows()
	{
		Monitor.Enter(_lock);
		if (_isRunning) 
		{
			Monitor.Exit(_lock);
			return;
		}
		_isRunning = true;
		while (rowsToProcess)
		{
			Monitor.Exit(_lock);;
			// ... do your stuff
			Monitor.Enter(_lock);
		}
		_isRunning = false;
		Monitor.Exit(_lock);
	}
