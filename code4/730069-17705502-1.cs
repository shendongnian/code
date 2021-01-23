    void Main()
    {
        TryParse("123").Dump();
        TryParse("xyz").Dump();
    }
    
    public static int TryParse(string s, int errorValue = 0)
    {
        int result;
        if (int.TryParse(s, out result))
            return result;
        return errorValue;
    }
