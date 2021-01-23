    public static string Join(this string text, params string[] stringsToJoin)
    {
        return String.Join(", ", stringsToJoin.Where(s => !string.IsNullOrEmpty(s))
                                              .ToArray());
    }
