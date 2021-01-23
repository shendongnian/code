    static Task MonitorProcessAsync(string process, Action<string> startAction, Action<string> exitAction)
    {
    	return Task.Factory.StartNew(() =>
    	{
    		bool isProcessRunning = false;
    
    		while (true)
    		{
                int count = Process.GetProcessesByName(process).Count();
    			if (count > 0 && !isProcessRunning)
    			{
    				startAction(process);
    				isProcessRunning = true;
    			}
    			else if (count == 0 && isProcessRunng)
    			{
    				exitAction(process);
    				isProcessRunning = false;
    			}
    
    			Thread.Sleep(1000);
    		}
    	});
    }
