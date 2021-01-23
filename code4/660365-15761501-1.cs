    public static bool TryGetBool(this string item)
    {
        bool b;
        Boolean.TryParse(item, out b);
        return b; 
    }
