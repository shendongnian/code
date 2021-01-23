    var rnd = new Random();
    var fakeSource = new Subject<Operation>();
    var producer = Observable
        .Interval(TimeSpan.FromMilliseconds(1000))
        .Subscribe(i => 
            {
				var op = new Operation();
                op.Type = rnd.NextDouble() < 0.5 ? "insert" : "delete";
                fakeSource.OnNext(op);
            });    
			
    var singleSource = fakeSource
		.Publish().RefCount();
	var query = singleSource
		// change this value to alter your "look at" time window
		.Buffer(TimeSpan.FromSeconds(5))	
		.Select(buff => buff.ToRuns(op => op.Type).Where(run => run.Count > 0));
			
	using(query.Subscribe(batch => 
	{
		foreach(var item in batch)
		{
			Console.WriteLine("{0}({1})", item.First().Type, item.Count);
		}
	}))
    {
        Console.ReadLine();
		producer.Dispose();		
    }
