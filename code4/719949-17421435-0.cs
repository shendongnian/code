    public static string GetIntegersOnly(this string str)
    {
        return new String(str.Where(Char.IsDigit).ToArray());
    }
    ...
    int value1 = Int32.Parse(parts[0].GetIntegersOnly())
