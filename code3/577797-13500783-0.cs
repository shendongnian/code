    static string GetConcatenationRecursively(Dictionary<string, string> d, string key)
    {
        if (key.Length == 1)
        {
            return d[key];
        }
        else
        {
            return string.Format(
                "{0} - {1}",
                GetConcatenationRecursively(d, key.Substring(0, key.Length - 2)),
                d[key]);
        }
    }
