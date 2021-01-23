    static readonly string[] Units = { "m2", "m3", "kg", "mm", "cm", 
                                       "m", "t", "h", "l" };
    private static bool IsUnit(string text)
    {
        return Units.Contains(text);
    }
