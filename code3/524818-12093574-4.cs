    Dictionary<string, int> ToGroupDictionary(string value)
    {
        return value.Split(',')
            .GroupBy(s => s.Trim())
            .ToDictionary(g => g.Key, g => g.Count());
    }
