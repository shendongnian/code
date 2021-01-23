    BlockingCollection<string> queue = new BlockingCollection<string>(listOfUrls);
    
    for (int x=0; x < MAX_THREADS; x++)
    {
    	Task.Factory.StartNew(() => 
        {
    		while (true)
    		{
    			string url = queue.Take();
    			// process url;
    		}
    	}, TaskCreationOptions.LongRunning);
    }
