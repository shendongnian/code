    private static readonly Regex rxVowels = new Regex( "[^aeiou]+" , RegexOptions.IgnoreCase ) ;
    public static string ExtractVowels_2( string s )
    {
      string vowels  = rxVowels.Replace( s , "" ) ;
      return vowels ;
    }
