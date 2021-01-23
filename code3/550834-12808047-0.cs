    var list1 = new List<int>() { 1, 1, 1, 2, 3 };
    var list2 = new List<int>() { 1, 1, 2, 2, 4 };
    var grouped1 =
        from n in list1
        group n by n
        into g
        select new {g.Key, Count = g.Count()};
    var grouped2 =
        from n in list2
        group n by n
        into g
        select new {g.Key, Count = g.Count()};
    var joined =
        from b in grouped2
        join a in grouped1 on b.Key equals a.Key
        select new {b.Key, Count = Math.Min(b.Count, a.Count)};
    var result = joined.SelectMany(a => Enumerable.Repeat(a.Key, a.Count));
    CollectionAssert.AreEquivalent(new[] {1, 1, 2}, result);
