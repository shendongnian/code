    DateTime startTime = DateTime.Now;
    
    DateTime endTime = DateTime.Now.AddSeconds( 75 );
     
    TimeSpan span = endTime.Subtract ( startTime );
    Console.WriteLine( "Time Difference (seconds): " + span.Seconds );
    Console.WriteLine( "Time Difference (minutes): " + span.Minutes );
    Console.WriteLine( "Time Difference (hours): " + span.Hours );
    Console.WriteLine( "Time Difference (days): " + span.Days );
    String yourString = string.Format("{0} days, {1} hours, {2} minues, {3} seconds",
        span.Days, span.Hours, span.Minutes, span.Seconds);
