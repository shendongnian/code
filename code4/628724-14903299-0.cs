    static IEnumerable<int> SuperExpensiveQuery()
    {
        Console.WriteLine("super expensive query (#1)");
        yield return 100;
        Console.WriteLine("super expensive query (#2)");
        yield return 200;
        Console.WriteLine("super expensive query (#3)");
        yield return 300;
        Console.WriteLine("super expensive query (#4)");
    }
    
    static IEnumerable<int> MakeMyQuery()
    {
        var someStaticData = new int[] { 1, 2, 3 };
        var deferredQuery = SuperExpensiveQuery();
        return someStaticData.Concat(deferredQuery);
    }
    
    static void Test()
    {
        var query = MakeMyQuery();
        for (int i = 0; i <= 7; i++)
        {
            Console.WriteLine("BEGIN Take({0})", i);
            foreach (var n in query.Take(i))
                Console.WriteLine("    {0}", n);
            Console.WriteLine("END Take({0})", i);
        }
        Console.ReadLine();
    }
