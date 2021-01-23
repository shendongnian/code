	var query =
		from b in subjEvent.Do(x =>
			Console.WriteLine("{0}onnected On: \t{1}",
				x ? "C" : "Disc",
				Thread.CurrentThread.ManagedThreadId))
		select b ? subjValue : Observable.Empty<int>();
		
	query.Switch().Subscribe(x =>
		Console.WriteLine("Recieved On: \t{0}",
			Thread.CurrentThread.ManagedThreadId));
