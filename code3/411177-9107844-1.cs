    public static double? TryParseInt(this string source)
    {
        double result;
        return double.TryParse(source, out result) ? result : (double?)null;
    }
    // usage
    bool ok = source.TryParseInt().HasValue;
