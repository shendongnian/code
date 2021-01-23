	using (Mutex mutex = new Mutex(true, "MyData"))
	{
		mutex.WaitOne();
		try
		{
			order = (int)IsolatedStorageSettings.ApplicationSettings["order"];
		}
		finally
		{
			mutex.ReleaseMutex();
		}
	}
    // do something with "order" here...
