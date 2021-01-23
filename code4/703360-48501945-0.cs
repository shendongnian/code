    // Main method:
    static void Main(string[] args)
    {
        IEnumerable<int> ints = Enumerable.Range(0, 100);
        var query = ints.Where(x =>
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{x}**, ");
            return x % 2 == 0;
        });
        DoForeach(query, "query");
        DoForeach(query, "query.ToList()");
        Console.ForegroundColor = ConsoleColor.White;
    }
    // DoForeach method:
    private static void DoForeach(IEnumerable<int> collection, string collectionName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- {0} FOREACH BEGIN: ---", collectionName);
        if (collectionName.Contains("query.ToList()"))
            collection = collection.ToList();
        foreach (var item in collection)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{item}, ");
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- {0} FOREACH END ---", collectionName);
    }
