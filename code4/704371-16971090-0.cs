	var r = new Random();
	bool[] vals = new bool[100000000];
	//initializing
	for (int i = 0; i < vals.Length; i++)
	{
		vals[i] = r.Next(2)==0;
	}
	var watch = Stopwatch.StartNew();
	
    //for loop benchmark
	List<int> indices = new List<int>(vals.Length);
	for(int i = 0; i < vals.Length; ++i)
	{
		if(!vals[i])
			indices.Add(i);
	}
	Console.WriteLine ("for loop: {0} ms", watch.ElapsedMilliseconds);
		
	watch.Restart();
    
    //LINQ benchmark
	List<int> falseIndices = vals.Where(flag => !flag)
								 .Select((flag, index) => index)
								 .ToList();
								
	Console.WriteLine ("LINQ: {0} ms", watch.ElapsedMilliseconds);	
