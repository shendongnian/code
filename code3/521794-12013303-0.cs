    public static string RemoveAll(this string input, char toRemove)
    {
       //produces a pattern like "\x1a+" which will match any occurrence
       //of one or more of the character with that hex value
       var pattern = @"\x" + ((int)toRemove).ToString("x") + "+";
    
       return Regex.Replace(input, pattern, String.Empty);
    }
    //usage
    var cleanString = dirtyString.RemoveAll((char)0x1a);
