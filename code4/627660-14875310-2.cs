    Dictionary<string, List<String>> dict = new Dictionary<string, List<String>>();
    dict.Add("STAR-016", new List<string>() { 
        "value a", "value b", "value c", "value 1, value 2, value 3", "value d"
    });
    foreach (var kvp in dict)
    {
        for (int i = kvp.Value.Count -1; i >= 0; i--)
        {
            string str = kvp.Value[i];
            if (str.IndexOf(',') != -1)
            {
                var parts = str.Split(',').Select(p => p.Trim());
                kvp.Value.RemoveAt(i);
                kvp.Value.InsertRange(i, parts);
            }
        }
    }
