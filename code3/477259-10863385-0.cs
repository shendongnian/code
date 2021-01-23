    public static void AddFormat<TKey>(this Dictionary<TKey, string> dictionary,
        TKey key,
        string formatString,
        params object[] argList)
    {
        dictionary.Add(key, string.Format(formatString, argList));
    }
