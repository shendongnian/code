    string[] ranges = new string[]{"0-100", "100-200", "500-1000"};
    var predicate = PredicateBuilder.False<Product>();
    
    foreach (var item in ranges)
    {
        int min = int.Parse(item.Split('-').First());
        int max = int.Parse(item.Split('-').Last());                
        predicate = predicate.Or(p => p.Amount >= min && p.Amount <= max);
    }
