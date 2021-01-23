    var t = tweet.GetType();
    foreach (var p in t.GetProperties())
    {
        Console.WriteLine(p.Name);
    }
    foreach (var f in t.GetFields())
    {
        Console.WriteLine(f.Name);
    }
