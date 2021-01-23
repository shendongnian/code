    public static int ConvertRomanNumtoInt(string strRomanValue)
    {
        Dictionary RomanNumbers = new Dictionary
        {
            {"M", 1000},
            {"CM", 900},
            {"D", 500},
            {"CD", 400},
            {"C", 100},
            {"XC", 90},
            {"L", 50},
            {"XL", 40},
            {"X", 10},
            {"IX", 9},
            {"V", 5},
            {"IV", 4},
            {"I", 1}
        };
        int retVal = 0;
        foreach (KeyValuePair pair in RomanNumbers)
        {
            while (strRomanValue.IndexOf(pair.Key.ToString()) == 0)
            {
                retVal += int.Parse(pair.Value.ToString());
                strRomanValue = strRomanValue.Substring(pair.Key.ToString().Length);
            }
        }
        return retVal;
    }
