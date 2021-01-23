    public static int? TryParseInt32(string s)
    {
        int i;
        if (int.TryParse(s, out i))
            return i;
        return null;
    }
