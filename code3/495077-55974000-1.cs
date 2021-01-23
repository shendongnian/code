    static void Main(string[] args)
    {
    	Console.WriteLine("Test Start Time: {0}", DateTime.Now);
    
    	// 10 seconds ago
    	int tc0 = CalculateTC(TimeSpan.FromSeconds(10));
    	Console.WriteLine("Expect 10 seconds ago: {0}", ConvertTickToDateTime(tc0));
    
    	// 10 minutes ago
    	int tc1 = CalculateTC(TimeSpan.FromMinutes(10));
    	Console.WriteLine("Expect 10 minutes ago: {0}", ConvertTickToDateTime(tc1));
    
    	// 10 hours ago
    	int tc2 = CalculateTC(TimeSpan.FromHours(10));
    	Console.WriteLine("Expect 10 hours ago: {0}", ConvertTickToDateTime(tc2));
    
    	// 1 Day ago
    	int tc3 = CalculateTC(TimeSpan.FromDays(1));
    	Console.WriteLine("Expect 1 Day ago: {0}", ConvertTickToDateTime(tc3));
    
    	// 10 Day ago
    	int tc4 = CalculateTC(TimeSpan.FromDays(10));
    	Console.WriteLine("Expect 10 Days ago: {0}", ConvertTickToDateTime(tc4));
    
    	// 30 Day ago
    	int tc5 = CalculateTC(TimeSpan.FromDays(30));
    	Console.WriteLine("Expect 30 Days ago: {0}", ConvertTickToDateTime(tc5));
    
    	// 48 Day ago
    	int tc6 = CalculateTC(TimeSpan.FromDays(48));
    	Console.WriteLine("Expect 48 Days ago: {0}", ConvertTickToDateTime(tc6));
    
    	// 50 Day ago (Should read as a more recent time because of the Environment.TickCount wrapping limit - within a day or two)
    	int tc7 = CalculateTC(TimeSpan.FromDays(50));
    	Console.WriteLine("Expect to not see 50 Days ago: {0}", ConvertTickToDateTime(tc7));
    	
    	// 10 Seconds ahead (Should read as a very old date - around 50 days ago)
    	int tc8 = Convert.ToInt32(Environment.TickCount + TimeSpan.FromSeconds(10).TotalMilliseconds);
    	Console.WriteLine("Expect to not see 10 seconds from now: {0}", ConvertTickToDateTime(tc8));	
    }
    
    
    private static int CalculateTC(TimeSpan timespan)
    {
    	int nowTick = Environment.TickCount;
    	double mSecToGoBack = timespan.TotalMilliseconds;
    
    	int tc;
    
    	if (Math.Abs(nowTick - int.MinValue) >= mSecToGoBack) // Then we don't have to deal with an overflow
    	{
    		tc = Convert.ToInt32(nowTick - mSecToGoBack);
    	}
    	else // Deal with the overflow wrapping
    	{
    		double remainingTime = nowTick + Math.Abs(Convert.ToDouble(int.MinValue));
    		remainingTime = mSecToGoBack - remainingTime;
    
    		tc = Convert.ToInt32(int.MaxValue - remainingTime);
    	}
    	return tc;
    }
    
 
