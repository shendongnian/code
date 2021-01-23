    public static double ParseValue(string value)
    {
        return double.Parse(string.Join("",
            value.Select(c => "+-.".Contains(c)
               ? "" + c: "" + char.GetNumericValue(c)).ToArray()),
            NumberFormatInfo.InvariantInfo);
    }
