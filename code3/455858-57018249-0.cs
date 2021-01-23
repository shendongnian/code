    List<string> list1 = new List<string> { "test", "otherTest" };
    List<string> list2 = new List<string> { "item", "otherItem" };
    List<string> list3 = new List<string> { "value", "otherValue" };
    
    var list = new List<List<string>>() { list1, list2, list3 }
        .Aggregate(
            Enumerable.Range(0, list1.Count).Select(e => new List<string>()),
            (prev, next) => prev.Zip(next, (first, second) => { first.Add(second); return first; })
        )
        .Select(e => new
        {
            a = e.ElementAt(0),
            b = e.ElementAt(1),
            c = e.ElementAt(2)
        });
