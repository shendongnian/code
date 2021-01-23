	var xs = new Subject<int>();
	
	xs.ObserveOn(Scheduler.ThreadPool).Subscribe(x =>
	{
		Console.WriteLine(x);
		if (x % 5 == 0)
		{
			throw new System.Exception("Bang!");
		}
	}, ex => Console.WriteLine(ex.Message));
	
	xs.OnNext(1);
	xs.OnNext(2);
	xs.OnNext(3);
	xs.OnNext(4);
	xs.OnNext(5);
