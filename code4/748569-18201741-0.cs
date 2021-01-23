    artistName= RemoveSymbols(artistName);
    albumName= RemoveSymbols(albumName);
    private static string RemoveSymbols(string input)
    {
        if(!String.IsNullOrEmpty(input))
           return input;
    
        return  Regex.Replace(input, "[?*/:]", string.Empty);
    }
