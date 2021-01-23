    List<int> list = Enumerable.Range( 0, 10000 ).ToList( );
    Stopwatch sw = Stopwatch.StartNew( );
    for ( int i = 0; i < 100000; i++ ) {
       List<int?> newList = new List<int?>( );
       for ( int j = 0; j < list.Count; j++ )
          newList.Add( ( int? ) list[ j ] );
    }
    sw.Stop( );
    TimeSpan timespan = sw.Elapsed;
    Console.WriteLine( String.Format( "For-Loop: {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10 ) );
    sw.Restart( );
    for ( int i = 0; i < 100000; i++ )
       List<int?> newList = list.Select( x => ( int? ) x ).ToList( );
    sw.Stop( );
    timespan = sw.Elapsed;
    Console.WriteLine( String.Format( "LINQ-Select: {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10 ) );
    sw.Restart( );
    for ( int i = 0; i < 100000; i++ )
       List<int?> newList = list.Cast<int?>( ).ToList( );
    timespan = sw.Elapsed;
    Console.WriteLine( String.Format( "LINQ-Cast: {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10 ) );
