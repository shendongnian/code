    var groups = files
        .Select(file => new {
            fInfo = file,
            Hash = hash.ComputeHash(file.Open(FileMode.Open)) }
        ).GroupBy(item => item.Hash);
    foreach (var grouping in groups)
    {
        Console.WriteLine("Files with hash value: {0}", grouping.Key);
        foreach(var item in grouping)
            Console.WriteLine(item.fInfo);
    }
