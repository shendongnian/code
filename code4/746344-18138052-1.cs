    public static IEnumerable<string> SplitEvery(this string s, int length)
    {
        int index = 0;
        while (index + length < s.Length)
        {
            yield return s.Substring(index, length);
            index += length;                
        }
        if (index < s.Length)
            yield return s.Substring(index, s.Length - index);
    }
