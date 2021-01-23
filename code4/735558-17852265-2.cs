    var items = new Dictionary<string, string>
    {
        {"C03", "C"},
        {"B01", "B"},
        {"A01", "A"},
        {"C02", "C"},
        {"A03", "A"},
        {"B03", "B"},
        {"B02", "B"},
        {"A02", "A"},
        {"C01", "C"}
    };
    var result = items.GroupBy(item => item.Value)
                .ToDictionary
                (
                    g => g.Key, 
                    g => g.Select(x => x.Key).ToList()
                );
    foreach (var item in result)
    {
        Console.Write("Values for key " + item.Key + ": ");
        foreach (var value in item.Value)
            Console.Write(value + " ");
        Console.WriteLine();
    }
