       int DaysBetween(DateTime d1, DateTime d2) {
    	TimeSpan span = d2.Subtract(d1);
    	return Math.Abs((int)span.TotalDays);
    }
///
    Console.WriteLine(DaysBetween(DateTime.Now.AddDays(10), DateTime.Now) );
