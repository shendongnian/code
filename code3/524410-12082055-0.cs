    public static Int32 StringToInt32(string str)
    {
        if (string.IsNullOrEmpty(str))
            return 0;
        else
            return Convert.ToInt32(str);
    }
