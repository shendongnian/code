    static void Main(string[] args)
    {
        IEnumerable<IEnumerable<int>> collection =
            new[]
            {
                new [] {1, 2, 3},
                new [] {4, 5, 6 },
                new [] {7, 8, 9}
            };
        Console.WriteLine("\tInitial");
        Print(collection);
        var transposed =
            Enumerable.Range(0, collection.First().Count())
                      .Select(i => collection.Select(j => j.ElementAt(i)));
        Console.WriteLine("\tTransposed");
        Print(transposed);
    }
    static void Print<T>(IEnumerable<IEnumerable<T>> collection)=>
        Console.WriteLine(string.Join(Environment.NewLine, collection.Select(i => string.Join(" ", i))));
