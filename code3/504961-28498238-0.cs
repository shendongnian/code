    var ts = TimeSpan.FromHours( 23.9 );
    Console.WriteLine( ts );
    Console.WriteLine( "{0:00}:{1:00}:{2:00}", ts.TotalHours, ts.Minutes, ts.Seconds );
    Console.WriteLine( "{0}:{1:00}:{2:00}", ts.TotalHours, ts.Minutes, ts.Seconds );
    Console.WriteLine( "{0}:{1:00}:{2:00}", 24*ts.Days+ts.Hours, ts.Minutes, ts.Seconds );
