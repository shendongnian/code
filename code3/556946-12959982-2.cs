    public static bool IsCapital(string str)
    {
        if (String.IsNullOrEmpty(str)) return false;
        if (str.Length == 1 &&  char.IsUpper(str[0])) return true;
        return char.IsUpper(str[0]) ? IsCapital(str.Substring(1)) :false;
    }
