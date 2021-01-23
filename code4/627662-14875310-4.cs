    Dictionary<string, List<String>> dict = new Dictionary<string, List<String>>();
    dict.Add("STAR-016", new List<string>() { 
        "value a", "value b", "value c", "value 1, value 2, value 3", "value d"
    });
    foreach (var kvp in dict)
    {
        for (int i = 0; i < kvp.Value.Count; i++)
        {
            string str = kvp.Value[i];
            if (str.Contains(','))
            {
                var parts = str.Split(',').Select(p => p.Trim());
                kvp.Value.RemoveAt(i);
                kvp.Value.InsertRange(i, parts);
            }
        }
    }
