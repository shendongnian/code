	Action<double> action =
		x =>
			Console.WriteLine(x);
	
	var ts0 = pairs.Select(p => p.Timestamp).Min();
		
	pairs
		.ForEach(p => 
			Scheduler
				.ThreadPool
				.Schedule(
					p.Timestamp.Subtract(ts0),
					() => action(p.Value)));
