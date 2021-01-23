    public static string NullStringIfZero(this int value)
    {
        return value != 0 ? value.ToString() : "null";
    }
    public static string NullStringIfZero(this decimal value)
    {
        return value != 0 ? value.ToString() : "null";
    }
