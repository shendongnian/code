    private static Regex _gtinRegex = new System.Text.RegularExpressions.Regex("^(\\d{8}|\\d{12,14})$");
    public static bool IsValidGtin(string code)
    {
        if (!(_gtinRegex.IsMatch(code))) return false; // check if all digits and with 8, 12, 13 or 14 digits
        code = code.PadLeft(14, '0'); // stuff zeros at start to garantee 14 digits
        //Sum all the digits including the check digit
        //Use (c - '0') to convert from char to int
        var mult = code.Select((c,i) => (c - '0')  * ((i % 2 == 0) ? 3 : 1));
        // STEP 2: "Add results together to create sum"
        int sum = mult.Sum();
        //If the digit was properly calculated, the sum should be a multiple of 10
        return (sum % 10) == 0;
    }
