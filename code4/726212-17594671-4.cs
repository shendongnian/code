    var processedDictionaries = Merger(
        rawListDict,
        new[] { "Product", "Region" },
        new Dictionary<string, Func<IEnumerable<object>, object>>
            {
                { "Profit", objects => objects.Cast<int>().Sum() }
            });
