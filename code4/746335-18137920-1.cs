    public static IEnumerable<string> SplitEvery( this string s , int n )
    {
      int limit = s.Length - ( s.Length % n ) ;
      int i = 0 ;
      
      while ( i < limit )
      {
        yield return s.Substring(i,n) ;
        i+=n ;
      }
      
      if ( i < s.Length )
      {
        yield return s.Substring(i) ;
      }
      
    }
