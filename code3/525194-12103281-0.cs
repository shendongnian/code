    private string RetainOnlyPrintableCharacters(char c)
    {
    //even if the character comes from a different codepage altogether, 
    //if the character exists in 1252 it will be returned in 1252 format.
        var ansiBytes = _ansiEncoding.GetBytes(new char[] {c});
    
        if (ansiBytes.Any())
        {
            if (ansiBytes.First().In(_printableCharacters))
            {
                return _ansiEncoding.GetString(ansiBytes);
            }
        }
        return string.Empty;
    }
