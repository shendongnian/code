    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var start = new DateTime(1, 1, 1, 9, 0, 0);
    		var end = new DateTime(1, 1, 1, 17, 0, 0);
    		
    		Console.WriteLine("{0} - Too early", 				TimeBetween(new DateTime(2014, 1, 1, 08, 59, 59, 999), start, end));
    		Console.WriteLine("{0} - On start time exclusive",	TimeBetween(new DateTime(2014, 1, 1, 09, 00, 00, 000), start, end, false));
    		Console.WriteLine("{0} - On start time inclusive",	TimeBetween(new DateTime(2014, 1, 1, 09, 00, 00, 000), start, end));
    		Console.WriteLine("{0} - After start time", 		TimeBetween(new DateTime(2014, 1, 1, 09, 00, 00, 001), start, end));		
    		Console.WriteLine("{0} - Before end time", 			TimeBetween(new DateTime(2014, 1, 1, 16, 59, 59, 999), start, end));
    		Console.WriteLine("{0} - On end time inclusive", 	TimeBetween(new DateTime(2014, 1, 1, 17, 00, 00, 000), start, end));
    		Console.WriteLine("{0} - On end time exclusive",	TimeBetween(new DateTime(2014, 1, 1, 17, 00, 00, 000), start, end, false));
    		Console.WriteLine("{0} - Too late", 				TimeBetween(new DateTime(2014, 1, 1, 17, 00, 00, 001), start, end));
    	}
    	
    	public static bool TimeBetween(DateTime check, DateTime start, DateTime end, bool inclusive = true)
    	{
    		var from = new DateTime(check.Year, check.Month, check.Day, start.Hour, start.Minute, start.Second, start.Millisecond);
    		var to = new DateTime(check.Year, check.Month, check.Day, end.Hour, end.Minute, end.Second, end.Millisecond);
    		
    		if (inclusive)
    			return from <= check && to >= check;
    		
    		return from < check && to > check;
    	}
    }
