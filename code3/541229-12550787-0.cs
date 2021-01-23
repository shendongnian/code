    using (var writer = new StreamWriter("test.csv"))
    {
        var lines = File.ReadLines("input.txt");
        var firstLine = lines.First();
    
        var widthList = firstLine.GroupBy(c => c)
                                 .Select(g => g.Count())
                                 .ToList();
    
        foreach (var line in lines)
        {
            var subLines = new List<string>();
    
            for (int i = 0; i < widthList.Count(); i++)
            {
                int startIndex = Enumerable.Range(0, i - 1)
                                      .Sum(x => widthList[x]) - 1;
    
                subLines.Add(line.Substring(startIndex, widthList[i]));
            }
    
            var csvLine = string.Join(",", subLines);
            writer.Write(csvLine);
        }
    }
