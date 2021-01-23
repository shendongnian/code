    static readonly Regex rxProductKey = new Regex( @"^..3..-...G.-..K..-M.6..-.R...$" , RegexOptions.IgnoreCase ) ;
    
    public bool IsValidProductKey( string key )
    {
      bool isValid = key != null && rxProductKey.IsMatch( key ) ;
      return isValid ;
    }
