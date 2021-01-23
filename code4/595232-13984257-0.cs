    var settings = new Dictionary<string, object>();
    var lines = File.ReadAllLines("...");
    foreach (var line in lines)
    {
        var parts = line.Split(new char[] { '=' }, 2);
        if (parts.Length != 2) continue;
        var keys = parts[0].Split('.');
        var value = parts[1];
        var dict = settings;
        for (int i = 0; i < keys.Length - 1; i++)
        {
            if (!dict.ContainsKey(keys[i]))
                dict.Add(keys[i], new Dictionary<string, object>());
            dict = (Dictionary<string, object>)dict[keys[i]];
        }
        dict.Add(keys[keys.Length - 1], value);
    }
