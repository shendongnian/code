    public static int Thousand(this int value)
    {
        return value * 1000;
    }
    
    public static int Million(this int value)
    {
        return value.Thousand() * 1000;
    }
    // etc.
