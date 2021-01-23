    public static decimal Thousand(this decimal value)
    {
        return value * 1000;
    }
    
    public static decimal Million(this decimal value)
    {
        return value.Thousand() * 1000;
    }
    // etc.
