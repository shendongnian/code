    foreach (string file in Directory.EnumerateFiles(NetWorkPath, "*.eml"))
    {
        var items = File.ReadAllLines(file)
            .Select(l => new
            {
                Key = l.Split(':')[0],
                Value = l.Split(':')[1],
            }
            .ToList();
        string myUser = items.First(i => i.Key == "From").Value;
    }
