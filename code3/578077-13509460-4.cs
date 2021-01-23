    public static IEnumerable<string> getAllSubstrings(this string word)
    {
        return from charIndex1 in Enumerable.Range(0, word.Length)
               from charIndex2 in Enumerable.Range(0, word.Length - charIndex1 + 1)
               where charIndex2 >= 2
               select word.Substring(charIndex1, charIndex2);
    }
