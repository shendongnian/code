    public static bool TryGetBool(this string item)
    {
        bool b = false;
        Boolean.TryParse(item, out b);
        return b; 
    }
