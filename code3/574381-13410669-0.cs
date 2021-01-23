    var prices = new Dictionary<int, int>();
    prices.Add(1, 100);
    prices.Add(2, 200);
    prices.Add(3, 100);
    prices.Add(4, 300);
    var test  = prices.GroupBy(r=> r.Value)
                      .ToDictionary(t=> t.Key, t=> t.ToList())
