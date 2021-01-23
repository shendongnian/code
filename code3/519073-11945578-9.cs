    public static bool ContainsSameWordsAs(this string first, string second)
    {
        var ignoreCase = StringComparer.OrdinalIgnoreCase;
        return first.Split().Any(word => second.Split().Contains(word, ignoreCase));
    }
