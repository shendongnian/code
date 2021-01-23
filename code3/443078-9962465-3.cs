    public delegate bool TryParser<T>(string pString, out T pResult);
    public static bool Is<T>(this string pString, TryParser<T> pTryParser)
    {
       T val;
       return pTryParser(pString, out val);
    }
