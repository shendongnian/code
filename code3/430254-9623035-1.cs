    internal class ExampleOnExecute
    {
    	private static EventWaitHandle _stopEvent;
    
    	public static EventWaitHandle StopEvent
    	{
    		get { return _stopEvent ?? (_stopEvent = new EventWaitHandle(false, EventResetMode.ManualReset)); }
    	}
    
    	public static void SpinOffThreads(IEnumerable<object> someCollection)
    	{
    		foreach(var item in someCollection)
    		{
    			// You probably do not want to manualy create a thread since these ideally would be small workers
    			// and action BeingInvoke runs in the ThreadPool
    			Action<object> process = BusyWait;
    
    			process.BeginInvoke(item, null, null);
    		}
    	}
    
    	private static void BusyWait(object obj)
    	{
    		// You can wait for however long you like or 0 is not waiting at all
    		const int sleepAmount = 1;
    
    		//     Blocks the current thread until the current instance receives a signal, using
    		//     a System.TimeSpan to specify the time interval.
    		//
    		// Parameters:
    		//   timeout:
    		//     A System.TimeSpan that represents the number of milliseconds to wait, or
    		//     a System.TimeSpan that represents -1 milliseconds to wait indefinitely.
    		//
    		// Returns:
    		//     true if the current instance receives a signal; otherwise, false.
    		while (!StopEvent.WaitOne(TimeSpan.FromMilliseconds(sleepAmount)))
    		{
    			// Do you work here
    			var foundIt = DidIFindIt();
    
    			if (foundIt)
    			{
    				// Signal all threads now to stop working we found it.
    				StopEvent.Set();
    			}
    		}
    	}
    
    	private static bool DidIFindIt()
    	{
    		return true;
    	}
    }
