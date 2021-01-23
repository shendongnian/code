    var items = Enumerable.Range<int>(1, 10)
    Console.WriteLine(items.Count()); // 10
    var original= items;
    items = items.ConcatSingle(11);
    Console.WriteLine(original.Count());   // 10
    Console.WriteLine(items.Count()); // 11
