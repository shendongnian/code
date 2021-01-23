    var predicate = PredicateBuilder.False<YourType>();
    var search = new[] {"aaaaa", "bbbbb"};
    foreach (string y in search)
    {
        string name = y;
        predicate = predicate.Or(x => x.Name == name);
    }
    sql = sql.Where(predicate);
