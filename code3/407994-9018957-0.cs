    private static void Main(string[] args)
    {
    	Stopwatch z1 = new Stopwatch();
    	Stopwatch z2 = new Stopwatch();
    	Stopwatch z3 = new Stopwatch();
    
    	int count = 100000000;
    
    	string text = "myTest";
    
    	z1.Start();
    	for (int i = 0; i < count; i++)
    	{
    		int tmp = 0;
    		if (string.Empty.Equals(text))
    		{
    			tmp++;
    		}
    	}
    	z1.Stop();
    
    	z2.Start();
    	for (int i = 0; i < count; i++)
    	{
    		int tmp = 0;
    		if (text.Equals(string.Empty))
    		{
    			tmp++;
    		}
    	}
    	z2.Stop();
    
    	z3.Start();
    	for (int i = 0; i < count; i++)
    	{
    		int tmp = 0;
    		if (string.IsNullOrEmpty(text))
    		{
    			tmp++;
    		}
    	}
    	z3.Stop();
    
    	Console.WriteLine(string.Format("Method 1: {0}", z1.ElapsedMilliseconds));
    	Console.WriteLine(string.Format("Method 2: {0}", z2.ElapsedMilliseconds));
    	Console.WriteLine(string.Format("Method 3: {0}", z3.ElapsedMilliseconds));
    
    	Console.ReadKey();
    }
