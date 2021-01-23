    public Task<string> DoWorkSequentially()
    {
       Task<int> AlphaTask = Task.Factory.StartNew(() => 4);
       Task<bool> BravoTask = Task.Factory.StartNew(() => true);
    
       //Prepare for Rx, and set filters to allow 'Zip' to terminate early
       //in some cases.
       IObservable<int> AsyncAlpha = AlphaTask.ToObservable().TakeWhile(x => x != 5);
       IObservable<bool> AsyncBravo = BravoTask.ToObservable().TakeWhile(y => y);
    
    	return (from alpha in AsyncAlpha
    		   from bravo in AsyncBravo
    		   select bravo.ToString() + alpha.ToString())
           .Timeout(TimeSpan.FromMilliseconds(200))
           .Concat(Observable.Return("Nothing"))   //Return Nothing if no result
           .Take(1)
    	   .ToTask();
    }
