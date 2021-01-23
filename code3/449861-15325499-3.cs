    private static Regex _gtinRegex = new System.Text.RegularExpressions.Regex("^(\\d{8}|\\d{12,14})$");
    public static bool IsValidGtin(string code)
    {
        if (!(_gtinRegex.IsMatch(code))) return false; // check if all digits and with 8, 12, 13 or 14 digits
        code = code.PadLeft(14, '0'); // stuff zeros at start to garantee 14 digits
        int[] mult = Enumerable.Range(0, 13).Select(i => int.Parse(code[i].ToString()) * ((i % 2 == 0) ? 3 : 1)).ToArray(); // STEP 1: without check digit, "Multiply value of each position" by 3 or 1
        int sum = mult.Sum(); // STEP 2: "Add results together to create sum"
        return (10 - (sum % 10)) % 10 == int.Parse(code[13].ToString()); // STEP 3 Equivalent to "Subtract the sum from the nearest equal or higher multiple of ten = CHECK DIGIT"
    }
