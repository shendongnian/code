    const string dir = "C:\\";
    var Sort = Directory.EnumerateFiles(dir, "*", SearchOption.AllDirectories)
                        .OrderByDescending(f => new FileInfo(f).Length);
    foreach (string n in Sort)
    {
            Console.WriteLine(n);
    }
