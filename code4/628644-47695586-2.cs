    public static OrderedDictionary<char, int> RomanNumerals = new OrderedDictionary<char,int> {
        {'i', 1}, {'v', 5}, {'x', 10}, {'l', 50}, {'c', 100}, {'d', 500}, {'m', 1000}
    };
    public static int FromRoman(string roman)
    {
        roman = roman.ToLower();
        int index = 0;
        foreach (var e in RomanNumerals.Reverse())
        {
            index = roman.IndexOf(e.Key);
            if (index > -1)
                return FromRoman(roman.Substring(index + 1)) + (index > 0 ? e.Value - FromRoman(roman.Substring(0, index)) : e.Value);
        }
        return 0;
    }
