    public static bool ContainsSameWordsAs(this string first, string second)
    {
        return first.GetSortedWords().SequenceEqual(second.GetSortedWords());
    }
    private static IEnumerable<string> GetSortedWords(this string source)
    {
        var result = source.Split().ToArray();
        Array.Sort(result);
        return result;
    }
