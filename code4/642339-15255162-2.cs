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
        // We want all "type 1s" and the buffered outputs of "type 2s"
        var query = ofType1.Merge(ofType2);
		
        // Let's set up a fake stream of data
        var running = true;
        var feeder = Task.Factory.StartNew(
           () => { 
             // until we say stop...
             while(running) 
             { 
                 // pump new Things into the stream every 500ms
                 source.OnNext(new Thing()); 
                 Thread.Sleep(500); 
             }
        });
        using(query.Subscribe(Console.WriteLine))
        {				
            // Block until we hit enter so we can see the live output 
            // from the above subscribe 
            Console.ReadLine();
            // Shutdown our fake feeder
            running = false;
            feeder.Wait();
         }
