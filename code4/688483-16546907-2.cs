    public static Int32 NumberOrZero(this string input)
    {
        Int32 output = 0;
        if (!string.IsNullOrWhiteSpace(input))
        {
            Int32.TryParse(input, out output);
        }
        return output;
    }
