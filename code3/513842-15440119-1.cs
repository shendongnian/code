    private static void Main(string[] args)
    {
        var items = new SortedTupleBag<decimal, string>
        {
            {2.94M, "Item A"}, 
            {9.23M, "Item B"}, 
            {2.94M, "Item C"}, 
            {1.83M, "Item D"}
        };
        foreach (var tuple in sortedTupleList)
        {
            Console.WriteLine("{0} {1}", tuple.Item1, tuple.Item2);
        }
        Console.ReadKey();
    }
