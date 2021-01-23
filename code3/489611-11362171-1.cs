    var isProcessingValues = this.PropertyChanges(x=>x.IsProcessing);
    isProcessingValues
    	.Where(isProcessing=>isProcessing)
    	.SelectMany(_=> 
    		Observable.Timer(TimeSpan.Zero, TimeSpan.FromMinutes(5))
    				  .TakeUntil(isProcessingValues.Where(isProcessing=>!isProcessing))
    	)
    	.Select(_=>GetFeeds())	//What does GetFeeds actually return?
    	.SubscribeOn(Scheduler.NewThread)
    	.Subscribe(feedData=>Console.WriteLine(feedData), 
    		ex=>Console.WriteLine (ex),
    		()=>Console.WriteLine (completed));
