    Dictionary<string, int> myDictionary = new Dictionary<string, int>();
    myDictionary.Add("First", 1);
    myDictionary.Add("Second", 2);
    myDictionary.Add("Third", 3);
    dynamic dynamicDictionary = myDictionary;
    foreach (var entry in dynamicDictionary)
    {
      object key = entry.Key;
      object val = entry.Value;
      ...whatever...
    }
