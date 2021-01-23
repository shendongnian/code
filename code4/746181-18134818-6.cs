    public bool ContainsDuplicateChars( string s )
    {
      if ( string.IsNullOrEmpty(s) ) return false ;
      bool containsDupes = false ;
      for ( int i = 1 ; i < s.Length && !containsDupes ; ++i )
      {
        containsDupes = s[i] == s[i-1] ;
      }
      return containsDupes ;
    }
