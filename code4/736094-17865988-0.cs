    public static string ReplaceAll(string text,
                                    Dictionary<string, string> replacements)
    {
        foreach (var pair in replacements)
        {
            text = text.Replace(pair.Key, pair.Value);
        }
        return text;
    }
