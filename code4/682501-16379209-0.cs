    private static bool IsNumeric(object input)
    {
        if (input == null) throw new ArgumentNullException("input");
        string inputStr = input.ToString();
        if (string.IsNullOrEmpty(inputStr)) return false;
        int periodCount = 0; //accept a string w/ 1dec to support values w/ a float
        return inputStr.Trim()
            .ToCharArray()
            .Where(c =>
            {
                if (c == '.') periodCount++;
                return (Char.IsDigit(c) || c == '.') && periodCount <= 1;
            })
            .Count() == inputStr.Trim().Length;
    }
