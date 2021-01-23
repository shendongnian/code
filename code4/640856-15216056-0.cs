     DateTime startTime = DateTime.Parse("13/02/2013 22.00");
    
     DateTime endTime = DateTime.Parse("14/02/2013 01.00");
    
     TimeSpan span = endTime.Subtract ( startTime );
     Console.WriteLine( "Time Difference (seconds): " + span.Seconds );
     Console.WriteLine( "Time Difference (minutes): " + span.Minutes );
     Console.WriteLine( "Time Difference (hours): " + span.Hours );
     Console.WriteLine( "Time Difference (days): " + span.Days );
