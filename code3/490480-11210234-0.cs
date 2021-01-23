    Dictionary<string, Dictionary<string, double>> lookupDictionary = new Dictionary<string, Dictionary<string, double>>();
    lookupDictionary.Select(outerKeyPair => new
    {
        Key = outerKeyPair.Key,
        Sum = outerKeyPair.Value.Values.Sum()
    })
    .OrderByDescending(pair => pair.Sum)
    .Take(10);
