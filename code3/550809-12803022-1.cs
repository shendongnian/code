    try
    {
        Console.WriteLine("Before fetching query");
        IEnumerable<int> query = getQuery();
        Console.WriteLine("After fetching query");
        foreach (var number in query)
        {
            Console.WriteLine("Inside foreach loop");
        }
        Console.WriteLine("After foreach loop");
    }
    catch (MeanException ex)
    {
        Console.WriteLine("Exception thrown: \n{0}", ex.ToString());
    }
