	void Main()
	{
		var source = Observable.Timer(TimeSpan.FromSeconds(3),TimeSpan.FromMilliseconds(300), Scheduler.TaskPool).Select(_=>new Thing());   
		var feed = source.Publish().RefCount();
		
		var ofType1 = feed.Where(t => t.ActivationType == "Type1");
		var ofType2 = feed
				.Where(t => t.ActivationType == "Type2")
				.Silencer(TimeSpan.FromSeconds(5));
		
		
		var query = ofType1.Merge(ofType2);        
		var subscription = query.Subscribe(t => Console.WriteLine("UPDATE: " + t.ID + " " + DateTime.Now.ToString("hh:mm:ss:fff")));    
		
		
		Console.ReadLine();
		subscription.Dispose();
	}
