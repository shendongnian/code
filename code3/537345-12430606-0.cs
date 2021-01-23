    public static string ReadSpecificLine1( string path , int lineNumber )
    {
      int cnt = 0 ;
      string desiredLine = File.ReadAllLines( path ).FirstOrDefault( x => (++cnt == lineNumber) ) ;
      return desiredLine ;
    }
    
    public static string ReadSpecificLine2( string path , int lineNumber )
    {
      string desiredLine = null ;
      using ( FileStream   stream = new FileStream( path , FileMode.Open , FileAccess.Read , FileShare.Read ) )
      using ( StreamReader reader = new StreamReader( stream ) )
      {
        int    i           = 0    ;
        string line        = null ;
        while ( null != (line=reader.ReadLine()) && ++i < lineNumber )
        {
        }
        if ( i == lineNumber && line != null )
        {
           desiredLine = line ;
        }
        return desiredLine ;
      }
    }
