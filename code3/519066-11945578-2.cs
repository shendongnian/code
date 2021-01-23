    public static bool ContainsSameWordsAs(this string first, string second)
    {
        return first.GetSortedWords().SequenceEqual(second.GetSortedWords());
        // if upper and lower case words should be seen as identical, use:
        // StringComparer.OrdinalIgnoreCase as a second argument to SequenceEqual
    }
    private static IEnumerable<string> GetSortedWords(this string source)
    {
        var result = source.Split().ToArray();
        Array.Sort(result);
        return result;
    }
