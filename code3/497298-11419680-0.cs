	using (Mutex mutex = new Mutex(true, "MyData"))
	{
		mutex.WaitOne();
		try
		{
			IsolatedStorageSettings.ApplicationSettings["order"] = 5;
		}
		finally
		{
			mutex.ReleaseMutex();
		}
	}
    //...
