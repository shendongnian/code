    public static bool ContainsSameWordsAs(this string first, string second)
    {
        var other = second.GetSortedWords();
        var ignoreCase = StringComparer.OrdinalIgnoreCase;
        return first.GetSortedWords().Any(word => other.Contains(word, ignoreCase));
    }
