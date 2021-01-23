    public static IEnumerable<string> EnumerateSegments( this IEnumerable<string> segments )
    {
      IEnumerator<string> enumerator = segments.GetEnumerator() ;
      StringBuilder sb = new StringBuilder() ;
      while ( enumerator.MoveNext() )
      {
        sb.Append( Path.DirectorySeparatorChar ).Append(enumerator.Current) ;
        yield return sb.ToString() ;
        int n = sb.Length ;
        sb.Append( Path.DirectorySeparatorChar ).Append("default") ;
        yield return sb.ToString() ;
        sb.Length = n ;
      }
    }
