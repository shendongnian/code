    static IEnumerable<int> AsCodePoints(this string s)
    {
        for(int i = 0; i < s.Length; ++i)
        {
            if(char.IsHighSurrogate(s, i))
            {
                // throws if given malformed sequences
                yield return char.ConvertToUtf32(s, i++);
            }
        }
    }
