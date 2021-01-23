    var en = new {Ints = new List<int>{1,2,3}.GetEnumerator()};
    while(en.Ints.MoveNext())
    {
        Console.WriteLine(x.Ints.Current);
    }
