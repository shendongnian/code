    public static IEnumerable<string> SplitEvery( this string s , int n )
    {
      StringBuilder sb = new StringBuilder(n) ;
      foreach ( char c in s )
      {
        if ( sb.Length == n )
        {
          yield return sb.ToString() ;
          sb.Length = 0 ;
        }
        sb.Append(c) ;
      }
    }
