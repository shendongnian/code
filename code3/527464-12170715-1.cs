    public string Tweak( string s , char c , int n )
    {
      StringBuilder sb = new StringBuilder( s.Length + ( s.Length % n ) + 1 ) ;
      for ( int i = 0 ; i < s.Length ; ++i )
      {
        sb.Append( s[i] ) ;
        if ( i % n == 0 ) sb.Append( c ) ;
      }
      return sb.ToString() ;
    }
