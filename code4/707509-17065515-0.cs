    var lines = File.ReadLines(myFilePath);
    var lineGroups = lines
                      .Where(line => line.Contains(","))
                      .Select(line => new{key = line.Split(',')[0], line})
                      .GroupBy(x => x.key);
    foreach(var lineGroup in lineGroups)
    {
        var key = lineGroup.Key;
        var lines = lineGroup.Select(x => x.line);
        //save lines to file
    }
