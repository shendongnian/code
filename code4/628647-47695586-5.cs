    
    // returns the value for a roman literal
    private static int romanValue(int index)
    {
        int basefactor = ((index % 2) * 4 + 1); // either 1 or 5...
        // ...multiplied with the exponentation of 10, if the literal is `x` or higher
        return index > 1 ? (int) (basefactor * System.Math.Pow(10.0, index / 2)) : basefactor;
    }
    public static int FromRoman(string roman)
    {
        roman = roman.ToLower();
        string literals = "mdclxvi";
        int value = 0, index = 0;
        foreach (char literal in literals)
        {
            value = romanValue(literals.Length - literals.IndexOf(literal) - 1);
            index = roman.IndexOf(literal);
            if (index > -1)
                return FromRoman(roman.Substring(index + 1)) + (index > 0 ? value - FromRoman(roman.Substring(0, index)) : value);
        }
        return 0;
    }
