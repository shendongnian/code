    var lineArray = new Dictionary<int, List<Int64>>();
    while ((line = sr.ReadLine()) != null)
    {
        var line = new List<Int64>();
        string[] values = line.Split(new[] { ',', ' ' },
                                     StringSplitOptions.RemoveEmptyEntries);
        line.AddRange(values.Select(t => Convert.ToInt64(t)));
        lineArray.Add(lineCount, line);
        lineCount++;
     }
