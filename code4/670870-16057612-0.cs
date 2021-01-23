    HashSet<int> t = new HashSet<int>();
    Random r = new Random();
    for (int i = 0; i < 100; i++)
    {
        t.Add(r.Next(0, 50));
    }
    foreach (int i in t)
    {
        Console.WriteLine(i);
    }
    Console.Read();
