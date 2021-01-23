    void Add(int key, string value)
    {
        List<string> values;
        if (!dict.TryGetValue(key, out values))
        {
            values = new List<string>();
            dict[key] = values;
        }
        values.Add(value);
    }
