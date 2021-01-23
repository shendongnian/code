    //the query is like LEFT JOIN in SQL
    var query = from x in list1
                join y in list2 on x.IDItem equals y.IDItem
                into z
                from q in z.DefaultIfEmpty()
                select new {IOne = x, ITwo = q};
    foreach (var pair in query)
    {
        if (pair.ITwo != null) // && pair.IOne.OneProperty != null
            pair.IOne.OneProperty = pair.ITwo.TwoProperty;
    }
    var resultList = query.Select(x => x.IOne).ToList();
