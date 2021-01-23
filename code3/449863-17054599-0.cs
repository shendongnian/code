    /// <summary>
    /// Validates a GTIN (UPC/EAN) using the terminating check digit
    /// </summary>
    /// <param name="code">the string representing the GTIN</param>
    /// <returns>True if the check digit matches, false if the code is not 
    /// parsable as a GTIN or the check digit does not match</returns>
    public static bool IsValidGtin(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            return false;
        if (code.Length != 8 && code.Length != 12 && code.Length != 13 
            && code.Length != 14)
            // wrong number of digits
            return false;
        int sum = 0;
        for (int i = 0; i < code.Length - 1 /* do not include check char */; i++)
        {
            if (!char.IsNumber(code[i]))
                return false;
            var cchari = (int)char.GetNumericValue(code[i]);
            // even (from the right) characters get multiplied by 3
            // add the length to align right
            if ((code.Length + i) % 2 == 0)
                sum += cchari * 3;
            else
                sum += cchari;
        }
        // validate check char
        char checkChar = code[code.Length - 1];
        if (!char.IsNumber(checkChar))
            return false;
        int checkChari = (int)char.GetNumericValue(checkChar);
        return checkChari == (10 - (sum % 10)) % 10;
    }
