    public static IEnumerable<string> EnumerateSegments( this IEnumerable<string> segments )
    {
      StringBuilder sb = new StringBuilder() ;
      foreach ( string segment in segements )
      {
        sb.Append( Path.DirectorySeparatorChar ).Append( segment ) ;
        yield return sb.ToString() ;
        int n = sb.Length ;
        sb.Append( Path.DirectorySeparatorChar ).Append("default") ;
        yield return sb.ToString() ;
        sb.Length = n ;
      }
    }
