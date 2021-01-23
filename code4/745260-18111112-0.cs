    static char[] vowels = "AEIOUaeiou".ToCharArray() ;
    public int VowelsInString( string s  )
    {
       
      int n = 0 ;
      for ( int i = 0 ; (i=s.IndexOfAny(vowels,i)) >= 0 ; )
      {
        ++n ;
      }
      return n;
    }
