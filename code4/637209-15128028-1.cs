    void Main()
    {
        using(var foo = new Foo(1))
        {
            Enumerable.Range(0, 10)
                .Select(t => 
                    Tuple.Create(t, new Thread(foo.LimitedSpaceAvailableActNow)))
                .ToList()
                .AsParallel()
                .ForAll(t => t.Item2.Start(t.Item1));
            Console.ReadLine();
        }
    }
