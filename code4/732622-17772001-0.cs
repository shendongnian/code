    var query = mylist.SelectMany(l => l.Select(inner => inner));
    var lookup = new Dictionary<string, Stock>();
    foreach (var stock in query)
    {
        if (!lookup.ContainsKey(stock.Name)) {
            lookup.Add(stock.Name, stock);
            continue;
        }
        lookup[stock.Name].Quantity += stock.Quantity;
    }
