    var source = new Subject<Thing>();
	
    var feed = source.Publish().RefCount();
    var ofType1 = feed.Where(t => t.ActivationType == "Type1");
    var ofType2 = feed
        // only window the type2s
        .Where(t => t.ActivationType == "Type2")
        // our "end window selector" will be a tick 30s off from start
        .Window(() => Observable.Timer(TimeSpan.FromSeconds(30)))
        // we want the first one in each window...
        .Select(lst => lst.Take(1))
        // moosh them all back together
        .Merge();
	var query = ofType1.Merge(ofType2);
		
	var running = true;
	var feeder = Task.Factory.StartNew(
		() => { 
			while(running) 
			{ 
				source.OnNext(new Thing()); 
				Thread.Sleep(500); 
			}
		});
	using(query.Subscribe(Console.WriteLine))
	{				
		Console.ReadLine();
		running = false;
		feeder.Wait();
	}
