    List<int> list = Enumerable.Range( 0, 10000 ).ToList( );
    Stopwatch sw = Stopwatch.StartNew( );
    for ( int i = 0; i < 100000; i++ ) {
       List<int?> newList = new List<int?>( );
       foreach( int integer in list )
          newList.Add( ( int? ) integer );
    }
    sw.Stop( );
    TimeSpan timespan = sw.Elapsed;
    Console.WriteLine( String.Format( "Foreach: {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10 ) );
    sw.Restart( );
    for ( int i = 0; i < 100000; i++ ){
       List<int?> newList = list.Select( x => ( int? ) x ).ToList( );
    }
    sw.Stop( );
    timespan = sw.Elapsed;
    Console.WriteLine( String.Format( "LINQ-Select: {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10 ) );
    sw.Restart( );
    for ( int i = 0; i < 100000; i++ ){
       List<int?> newList = list.Cast<int?>( ).ToList( );
    }
    sw.Stop();
    timespan = sw.Elapsed;
    Console.WriteLine( String.Format( "LINQ-Cast: {0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10 ) );
