    var times = new List<DateTime>()
    	{
    		DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(3), DateTime.Now.AddDays(4)
    	};
    
    var cutoff = DateTime.Now.AddDays(2);
    
    var timesAfterCutoff = times.SkipWhile(datetime => datetime.CompareTo(cutoff) < 1)
    	.Select(datetime => datetime);
    
    foreach (var dateTime in timesAfterCutoff)
    {
    	Console.WriteLine(dateTime);
    }
    
    Console.ReadLine();
