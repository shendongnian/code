    BlockingCollection<string> queue = new BlockingCollection<string>(listOfUrls);
    
    for (int x=0; x < MaxThreads; x++)
    {
    	Task.Factory.StartNew(() => 
        {
    		while (true)
    		{
    			string url = queue.Take(); // blocks until url is available
    			// process url;
    		}
    	}, TaskCreationOptions.LongRunning);
    }
