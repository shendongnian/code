    static IEnumerable<int> GetData()
    {
        Console.WriteLine("a");
        yield return 0;
        Console.WriteLine("b");
        yield return 1;
        Console.WriteLine("c");
        yield return 2;
        Console.WriteLine("d");
    }
    static void Main()
    {
        Console.WriteLine("start");
        var data = GetData();
        Console.WriteLine("got data");
        foreach (var item in data)
            Console.WriteLine(item);
        Console.WriteLine("end");
    }
