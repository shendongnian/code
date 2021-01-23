    SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
    dict.Add("Exchange C", 200);
    dict.Add("Exchange A", 200);
    dict.Add("Exchange V", 100);
    foreach (var kvp in dict)
    {
        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
    }
