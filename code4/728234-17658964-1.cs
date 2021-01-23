    List<string> mutable = new List<string>();
    ReadOnlyCollection<string> funky = new ReadOnlyCollection<string>(mutable);
    Console.WriteLine(funky.Count); // 0
    mutable.Add("xyz");
    Console.WriteLine(funky.Count); // 1
