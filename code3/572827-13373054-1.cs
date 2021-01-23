    static void MonitorProcess(string process, Action startAction, Action exitAction)
    {
    	Task.Factory.StartNew(() =>
    	{
    		bool isProcessRunning = false;
    
    		while (true)
    		{
                        int count = Process.GetProcessesByName(process).Count();
    			if (count > 0 && !isProcessRunning)
    			{
    				startAction();
    				isProcessRunning = true;
    			}
    			else if (count == 0) && isProcessRunng)
    			{
    				exitAction();
    				isProcessRunning = false;
    			}
    
    			Thread.Sleep(1000);
    		}
    	});
    }
