    var file = File.OpenText(myFile);
    var dict = strIndexes.Split(',')
        .Select(Int32.Parse)
        .ToDictionary(i => i, i => new List<string>());
                
    while(!file.EndOfStream)
    {
        var line = file.ReadLine().Split('|').ToArray();
        foreach(var entry in dict)
            entry.Value.Add(line[entry.Key]);
    }
    file.Dispose();
