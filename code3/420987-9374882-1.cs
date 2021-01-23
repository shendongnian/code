    public static int ComputeTime(string time)
    {
    	TimeSpan ts;
    
    	if (TimeSpan.TryParse(time, out ts))
    	{
    		return (60 - ts.Minutes) % 30;
    	}
    
    	throw new ArgumentException("Time is not valid", "time");
    }
    
    private static void Main(string[] args)
    {
    	string test1 = "7:27";
    	string test2 = "7:42";
    
    	Console.WriteLine(ComputeTime(test1));
    	Console.WriteLine(ComputeTime(test2));
    
    	Console.ReadLine();
    }
