    collection.Insert(new C { Id = 1, X = 3 });
    collection.Insert(new C { Id = 2, X = 2 });
    collection.Insert(new C { Id = 3, X = 1 });
    Console.WriteLine("Using MongoDB query:");
    foreach (var document in collection.Find(Query.GT("X", 1)).SetSortOrder("X"))
    {
        Console.WriteLine(document.X);
    }
    Console.WriteLine();
    Console.WriteLine("Using LINQ:");
    foreach (var document in collection.AsQueryable().Where(c => c.X > 1).OrderBy(c => c.X))
    {
        Console.WriteLine(document.X);
    }
    Console.WriteLine();
