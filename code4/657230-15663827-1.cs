    public static IEnumerable<string> LazySplit(this string text, string separator)
    {
        int start = 0;
        while (true)
        {
            int end = text.IndexOf(separator, start);
            if (end == -1)
            {
                // Note: if the string ends with the separator, this will yield
                // an empty string
                yield return text.Substring(start);
                yield break; // This will terminate the otherwise-infinite loop
            }
            yield return text.Substring(start, end - start);
            start = end + separator.Length;
        }
    }
