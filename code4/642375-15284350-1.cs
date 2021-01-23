    static void DisposeOnAbort()
    {
    	Thread t = new Thread(() =>
    	{
    		Console.WriteLine("Using connection wrapper");
    		using (ConnectionWrapper wrapper = new ConnectionWrapper())
    		{
    
    			while (true)
    			{
    				Thread.Sleep(1000);
    			}
    		}
    	});
    	t.Start();
    	Thread.Sleep(1000);
    	Console.WriteLine("Aborting thread..");
    	t.Abort();
    }
