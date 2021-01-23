    public static string CustomFormat(string format, Dictionary<string, string> data)
    {
        foreach (var kvp in data)
        {
            string pattern = string.Format("{{{0}}}", kvp.Key);
            format = format.Replace(pattern, kvp.Value);
        }
        return format;
    }
