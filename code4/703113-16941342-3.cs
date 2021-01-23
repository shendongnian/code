    Dictionary<string, Dictionary<string, string>> dict;
    foreach (string key in dict.Keys)
    {
        foreach (var innerDict in dict[key].Select(k => k.Value))
        {
        }
    }
