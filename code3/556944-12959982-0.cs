    public static bool IsCapital(string str)
    {
        if (str.Length == 1 &&  char.IsUpper(str[0])) return true;
        if (char.IsUpper(str[0])) return IsCapital(str.Substring(1));
        return false;
    }
