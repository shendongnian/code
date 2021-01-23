	void Main()
	{
		var headers = Enumerable.Range(1,1000).ToDictionary(i => "K"+i,i=> i % 2 == 0 ? null : "V"+i);
		var stopwatch = new Stopwatch(); 
		var sb = new StringBuilder();
		
		stopwatch.Start();
		
		foreach (var header in headers.Where(header => !String.IsNullOrEmpty(header.Value)))
			sb.Append(header);
		stopwatch.Stop();
		Console.WriteLine("Using LINQ : " + stopwatch.ElapsedTicks);
		
		sb.Clear();
		stopwatch.Reset();
		
		stopwatch.Start();
		foreach (var header in headers)
		{
			if (String.IsNullOrEmpty(header.Value)) continue;
			sb.Append(header);
		}
		stopwatch.Stop();
		
		Console.WriteLine("Using continue : " + stopwatch.ElapsedTicks);
		
	}
