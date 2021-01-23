    var pairs = new List<Tuple<bool?, string>>
    {
        Tuple.Create(DB.DbColumn_1, "thing 1"),
        Tuple.Create(DB.DbColumn_2, "thing 2")
        //...other columns
    };
    var things = string.Join(";", pairs.Where(x => x.Item1.GetValueOrDefault()).Select(x => x.Item2));
