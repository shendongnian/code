    inputStream.Select(n => Observable.StartAsync((token => Task.Run(() =>
    {
    	if (token.IsCancellationRequested)
    	{
    		// .. don't need to do anything
    		return 0;
    	}
    	else
    	{
    		Thread.Sleep(TimeSpan.FromSeconds(1));
    		return n * n;
    
    	}					
    }))))
    .Switch()
    .Subscribe(Console.WriteLine);
