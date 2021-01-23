    public static IEnumerable<string> SplitEvery(this string s, int length)
    {
        return s.Where((c, index) => index % length == 0)
               .Select((c, index) => String.Concat(
                    s.Skip(index * length).Take(length)
                 )
               );
    }
