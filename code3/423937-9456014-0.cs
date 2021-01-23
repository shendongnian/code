    var di = new DirectoryInfo(@"C:/Music/");
    var extensionCounts = di.EnumerateFiles("*.*", SearchOption.AllDirectories)
                            .GroupBy(x => x.Extension)
                            .Select(g => new { Extension = g.Key, Count = g.Count() })
                            .ToList();
    foreach (var group in extensionCounts)
    {
        Console.WriteLine("There are {0} files with extension {1}", group.Count, 
                                                                    group.Extension);
    }
