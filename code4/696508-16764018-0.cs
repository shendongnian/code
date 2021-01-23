    var sorted = 
        File.ReadLines(inputPath)
            .Select(line => new { 
                SortKey = Int32.Parse(line.Split(',')[2]),
                Line = line 
             })
            .OrderBy(x => x.SortKey)
            .Select(x => x.Line);
    File.WriteAllLines(outputPath, sorted)
