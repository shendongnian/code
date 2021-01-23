    IList<byte> list = new List<byte>() { 1, 2, 3, 4 };
    var collection = new ReadOnlyCollection<byte>(list);
    
    // Outputs: 1, 2, 3, 4.
    foreach (var item in collection)
    {
        Console.WriteLine(item);
    }
    
    list.Clear();
    list.Add(5);
    list.Add(6);
    list.Add(7);
    
    // Outputs: 5, 6, 7
    Console.WriteLine();
    foreach (var item in collection)
    {
        Console.WriteLine(item);
    }
    
    Console.ReadKey();
