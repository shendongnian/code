    var lineArray = new List<List<Int64>>();
    foreach (var lineString in File.ReadAllLines("path"))
    {
        var line = new List<Int64>();
        string[] values = lineString.Split(new[] { ',', ' ' },  
                                           StringSplitOptions.RemoveEmptyEntries);
        line.AddRange(values.Select(t => Convert.ToInt64(t)));
        lineArray.Add(line);
    }
