    inputStream.Select(n => Observable.Create<int>((observer, token) => Task.Run(() =>
    {
    	while (!token.IsCancellationRequested)
    	{
    		Thread.Sleep(TimeSpan.FromSeconds(1));
    		observer.OnNext(n * n);
    	}
    
    	observer.OnCompleted();
    })))
    .Switch()
    .Subscribe(Console.WriteLine);
