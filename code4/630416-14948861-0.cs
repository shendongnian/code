    List<Tuple<int, int>> collection = new List<Tuple<int, int>>();
    collection.Add(new Tuple<int, int>(1, 1));
    if (collection.Contains(new Tuple<int, int>(1, 1))
    {
        Console.WriteLine("This will NEVER happen.");
    }
    collection.Remove(new Tuple<int, int>(1, 1);
    Console.WriteLine("{0}", collection.Count); // => 1
