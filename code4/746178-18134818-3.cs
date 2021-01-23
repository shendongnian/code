    public static class EnumerableHelpers
    {
      public static IEnumerable<Tuple<char,int>> RunLengthEncoder( this IEnumerable<char> list )
      {
        char? prev  = null ;
        int   count = 0 ;
        
        foreach ( char curr in list )
        {
          if      ( prev == null ) { ++count ; prev = curr ; }
          else if ( prev == curr ) { ++count ;               }
          else if ( curr != prev )
          {
            yield return new Tuple<char, int>((char)prev,count) ;
            prev = curr ;
            count = 1 ;
          }
        }
      }
    }
