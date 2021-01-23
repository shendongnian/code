    var lines = File.ReadLines(myFilePath);
    var lineGroups = lines
                      .Where(line => line.Contains(","))
                      .Select(line => new{key = line.Split(',')[0], line})
                      .GroupBy(x => x.key);
    foreach(var lineGroup in lineGroups)
    {
        var key = lineGroup.Key;
        var keySpecificLines = lineGroup.Select(x => x.line);
        //save keySpecificLines to file
    }
