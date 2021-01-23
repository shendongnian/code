    Dictionary<string, List<double>> dictionary = ...
    var length = dictionary.First().Value.Length;
    var maximum = Enumerable.Range(0, length)
                            .Select(i => dictionary.Values.Select(d => d[i]).Sum())
                            .Max(); // 55
