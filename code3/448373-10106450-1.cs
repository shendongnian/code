    SortedDictionary<decimal, long> a = new SortedDictionary<decimal, long>();
    SortedDictionary<decimal, long> b = new SortedDictionary<decimal, long>();
    
    a.Add(0, 10);
    a.Add(1, 10);
    a.Add(2, 100);
    a.Add(100, 1);
    
    b.Add(0, 4);
    b.Add(4, 4);
    b.Add(2, 10);
    
    var result = a.Union(b)
    	.GroupBy(x => x.Key)
    	.ToDictionary(x => x.Key, x => x.Select(y => (long)y.Value).ToList());
