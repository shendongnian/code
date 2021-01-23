    var lineArray = new Dictionary<int, List<Int64>>();
    int lineCount = 0;
    foreach (var lineString in File.ReadAllLines("path"))
    {
        var line = new List<Int64>();
        string[] values = lineString.Split(new[] { ',', ' ' },  
                                           StringSplitOptions.RemoveEmptyEntries);
        line.AddRange(values.Select(t => Convert.ToInt64(t)));
        lineArray.Add(lineCount++, line);
    }
