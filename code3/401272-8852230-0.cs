    IDictionary<string, int> counts = new Dictionary<string, int>();
    foreach (string value in list)
    {
        if (!counts.ContainsKey(value))
            counts.Add(value, 0);
        
        counts[value]++; 
    }
    foreach (string value in counts.Keys)
    {
        System.Diagnostics.Debug
            .WriteLine("\"{0}\" occurs {1} time(s).", value, counts[value]);
    }
