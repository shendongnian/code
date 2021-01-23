    static readonly Regex rxVowels = new Regex( @"[^AEIOU]+" , RegexOptions.IgnoreCase ) ;
    public int VowelCount( string s )
    {
      int n = rxVowels.Replace(s,"").Length ;
      return n ;
    }
