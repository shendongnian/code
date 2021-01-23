    int testCount = 1000000;
    var stringList = new[] { "A", "BB", "CCC", "DDDD" };
    
    Func<string, string> elementSelector = (value) => value;
    
    var stopwatch = Stopwatch.StartNew();
    
    for (int i = 0; i < testCount; i++)
    {
    	var dictionary = new Dictionary<int, string>();
    	Func<string, int> keySelector = (value) => value.Length;
    	foreach (var s in stringList)
    	{
    		if (keySelector != null && elementSelector != null)
    		{
    			dictionary.Add(keySelector(s), elementSelector(s));
    		}
    	}
    }
    
    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds / testCount);
    
    var stopwatch2 = Stopwatch.StartNew();
    
    for (int i = 0; i < testCount; i++)
    {
    	var dictionary2 = stringList.ToDictionary(s => s.Length);
    }
    
    stopwatch2.Stop();
    Console.WriteLine(stopwatch2.Elapsed.TotalMilliseconds / testCount);
    
    Console.ReadKey();
