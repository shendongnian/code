    foreach (string file in Directory.EnumerateFiles(NetWorkPath, "*.eml"))
    {
        var items = File.ReadAllLines(file)
            .Select(l => l.Split(new[] { ':' }))
            .Select(l => new 
            {
                Key = s[0].Trim(),
                Value = s[1].Trim()
            })
            .ToList();
        string myUser = items.First(i => i.Key == "From").Value;
    }
