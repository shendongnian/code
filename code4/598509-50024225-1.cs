	Task task = RunLimitedNumberAtATime(10,
		Enumerable.Range(1, 100),
		async x =>
		{
			Console.WriteLine($"Starting task {x}");
			await Task.Delay(100);
			Console.WriteLine($"Finishing task {x}");
		});
