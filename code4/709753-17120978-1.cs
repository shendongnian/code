    public static void IsValid(string source)
    {
        //this will not affect the original as strings are immutable
        source = source.Trim(); 
        if (source.Length != 12) return false;
        return source.Take(4).All(char.IsLetter)
             && source.Skip(4).All(char.IsDigit);
    }
