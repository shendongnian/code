    static string DictionaryToString(IDictionary d)
    {
        var vals = new List<string>();
        foreach (DictionaryEntry de in d)
        {
            vals.Add(de.Key.ToString() + ": " + de.Value.ToString());
        }
        return String.Join("\n", vals);
    }
