    public static IEnumerable<string> EnumerateSegments( this IEnumerable<string> segments )
    {
      IEnumerator<string> enumerator = segments.GetEnumerator() ;
      StringBuilder sb = new StringBuilder() ;
      string separator = null ;
      string slash     = new String( Path.DirectorySeparatorChar , 1 ) ;
      while ( enumerator.MoveNext() )
      {
        sb.Append( separator ?? "" ).Append(enumerator.Current) ;
        separator = slash ;
        yield return sb.ToString() ;
        int n = sb.Length ;
        sb.Append( separator ).Append("default") ;
        yield return sb.ToString() ;
        sb.Length = n ;
      }
    }
