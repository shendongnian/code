    // Return the digit as a char to avoid bothering to convert digits to their
    // numeric values.
    private char GetEffectiveDigit(string text, int digitNumber)
    {
        int index = text.Length - digitNumber;
        return index < 0 ? '0' : text[index];
    }
    private int CompareNumbers(string x, string y)
    {
        for (int i = int.Max(x.Length, y.Length); i >= 0; i--)
        {
            char xc = GetEffectiveDigit(x, i);
            char yc = GetEffectiveDigit(y, i);
            int comparison = xc.CompareTo(yc);
            if (comparison != 0)
            {
                return comparison;
            }
        }
        return 0;
    }
