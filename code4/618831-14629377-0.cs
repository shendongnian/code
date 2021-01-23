    inputStream.Select(n => Observable.Create<int>((observer, token) => Task.Run(() =>
    {
    	if (token.IsCancellationRequested)
    	{
    		// .. don't need to do anything
    	}
    	else
    	{
    		Thread.Sleep(TimeSpan.FromSeconds(5)); 
    		observer.OnNext(n * n);
    		observer.OnCompleted();	
    	}					
    })))
    .Switch()
    .Subscribe(Console.WriteLine);
