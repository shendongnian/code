    var prices = new Dictionary<int, int>();
    prices.Add(1, 100);
    prices.Add(2, 200);
    prices.Add(3, 100);
    prices.Add(4, 300);
    
    Dictionary<int, List<int>> grouping = new Dictionary<int, List<int>>();
    
    var enumerator = prices.GetEnumerator();
    while (enumerator.MoveNext())
    {
        var pair = enumerator.Current;
        if (!grouping.ContainsKey(pair.Value))
            grouping[pair.Value] = new List<int>();
        grouping[pair.Value].Add(pair.Key);
    }
