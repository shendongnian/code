    static void Main( string[] args )
    {
      int[,] values = new int[1024,9];
      Random rng = new Random() ;
  
      // initialise the array
      for ( int r = 0 ; r < 1024 ; ++r )
      {
        for ( int c = 0 ; c < 9 ; ++c )
        {
          values[r,c] = rng.Next() ;
        }
    
        int x = rng.Next(10) ;
        if ( x == 1 )
        {
          values[r,8] = 0 ;
        }
      }
  
      int? minValue = null ;
      int? minRow   = null ;
      int? minCol   = null ;
      for ( int r = 0 ; r < 1024 ; ++r )
      {
        bool skipRow = 0 == values[r,8] ;
        if ( skipRow ) continue ;
        for ( int c = 0 ; c < 8 ; ++c )
        {
          int cell = values[r,c] ;
          if ( !minValue.HasValue || cell < minValue )
          {
            minValue = cell ;
            minRow   = r ;
            minCol   = c ;
          }
        }
      }
      // display the results
      if ( minValue.HasValue )
      {
        Console.WriteLine( "Minimum: values[{0},{1}] is {2}" , minRow , minCol , minValue );
      }
      else
      {
        Console.WriteLine( "all rows skipped" );
      }
      return ;
    }
