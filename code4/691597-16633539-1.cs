    public static double ParseValue(string value)
    {
        return double.Parse(string.Join("",
            value.Select(c => c == '.' ? "." : "" + char.GetNumericValue(c))),
            NumberFormatInfo.InvariantInfo);
    }
