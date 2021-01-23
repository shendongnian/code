    public static bool IsInt(this string pString)
    {
       int value;
       return int.TryParse(pString, out value);
    }
