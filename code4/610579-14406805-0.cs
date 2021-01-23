    List<int> keys = new List<int>();
    List<string> values = new List<string>();
    foreach (KeyValuePair<int, string>[] pair in partitioned)
    {
        foreach (KeyValuePair<int, string> k in pair)
        {
            keys.Add(k.Key);
            values.Add(k.Value);
        }
    }
    keyArray = keys.ToArray();
    valueArray = values.ToArray();
