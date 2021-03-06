    public static string GetMaskedNumber(string number)
    {
        if (String.IsNullOrEmpty(number))
            return string.Empty;
    
        if (number.Length <= 5)
            return number;
    
        string last5 = number.Substring(number.Length - 5, 5);
        var maskedChars = new StringBuilder();
        for (int i = 0; i < number.Length - 5; i++)
        {
            maskedChars.Append(number[i] == '-' ? "-" : "#");
        }
        return maskedChars + last5;
    }
