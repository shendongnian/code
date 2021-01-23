    public int HexStringCompare(string value1, string value2)
    {
        string InvalidHexExp = @"[^\dabcdef]";
        string HexPaddingExp = @"^(0x)?0*";
        //Remove whitespace, "0x" prefix if present, and leading zeros.  
        //Also make all characters lower case.
        string Value1 = Regex.Replace(value1.Trim().ToLower(), HexPaddingExp, "");
        string Value2 = Regex.Replace(value2.Trim().ToLower(), HexPaddingExp, "");
        //validate that values contain only hex characters
        if (Regex.IsMatch(Value1, InvalidHexExp))
        {
            throw new ArgumentOutOfRangeException("Value1 is not a hex string");
        }
        if (Regex.IsMatch(Value2, InvalidHexExp))
        {
            throw new ArgumentOutOfRangeException("Value2 is not a hex string");
        }
        int Result = Value1.Length.CompareTo(Value2.Length);
        if (Result == 0)
        {
            Result = Value1.CompareTo(Value2);
        }
        return Result;
    }
