    private static readonly char[] vowel = "aeiouAEIOU".ToArray() ;
    public static string ExtractVowels_1( string s )
    {
      if ( s == null ) throw new ArgumentNullException("s");
      
      StringBuilder sb = new StringBuilder( s.Length ) ;
      
      for ( int i = s.IndexOfAny(vowel) ;  i >= 0 ; i = s.IndexOfAny(vowel , i+1 ) )
      {
        sb.Append(s[i]) ;
      }
      return sb.ToString() ;
    }
