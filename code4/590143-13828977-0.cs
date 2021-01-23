       var myLines = new List<string> { "Alpha", "Beta", "Gamma", "Omega" };
    
       var stringResult = new ConcurrentBag<string>();
    
       ParallelOptions parallelOptions = new ParallelOptions();
    
       parallelOptions.MaxDegreeOfParallelism = 2;
    
       Parallel.ForEach( myLines, parallelOptions, line =>
       {
          if (line.Contains( "e" ))
             stringResult.Add( line );
    
       } );
    
       Console.WriteLine( string.Join( " | ", stringResult ) );
       // Outputs Beta | Omega
