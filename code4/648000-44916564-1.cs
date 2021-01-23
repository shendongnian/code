	void Main()
	{
		Console.WriteLine("Build time: {0} ms", BuildInput());
	    Console.WriteLine("Time substring: {0} ms, Time take: {1} ms", MeasureSubstring(), MeasureTake());
	}
	
	internal const int RETRIES = 5000000;
	static internal List<string> input;
	
	// Measure substring time
	private static long MeasureSubstring()
	{
		var v = new List<string>();
	    long ini = Environment.TickCount;
		
	    foreach (string test in input)
	        if (test.Length > 18)
	        {
	            v.Add(test.Substring(18));
	        }
		//v.Count().Dump("entries with substring");
		//v.Take(5).Dump("entries with Sub");
		
	    return Environment.TickCount - ini;
	}
	
	// Measure take time
	private static long MeasureTake()
	{
		var v = new List<string>();
	    long ini = Environment.TickCount;
		
	    foreach (string test in input)
		    if (test.Length > 18) v.Add(new string(test.Take(18).ToArray()));
		
		//v.Count().Dump("entries with Take");
		//v.Take(5).Dump("entries with Take");
		
	    return Environment.TickCount - ini;
	}
	
	// Create a list with random strings with random lengths
	private static long BuildInput()
	{
	    long ini = Environment.TickCount;
		Random r = new Random();
	    input = new List<string>();
		
	    for (int i = 0; i < RETRIES; i++)
	        input.Add(Guid.NewGuid().ToString().Substring(1,r.Next(0,36)));
	
	    return Environment.TickCount - ini;
	}
