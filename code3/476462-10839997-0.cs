	var coldObservable = Observable
		.Interval(TimeSpan.FromSeconds(1))
		.ObserveOn(Scheduler.TaskPool)
		.Select(_ => DoSomething());
		
	var refCountObs = coldObservable.Publish().RefCount();
	
	CompositeDisposable d = new CompositeDisposable();
	d.Add(refCountObs.Subscribe(n => Console.WriteLine("First got: " + n)));
	d.Add(refCountObs.Subscribe(n => Console.WriteLine("Second got: " + n)));
	d.Add(refCountObs.Subscribe(n => Console.WriteLine("Third got: " + n)));
	
	//Wait a bit for work to happen
	System.Threading.Thread.Sleep(10000);
	
	//Everyone unsubscribes
	d.Dispose();
	
	//Observe that DoSomething is not called.
	System.Threading.Thread.Sleep(3000);
