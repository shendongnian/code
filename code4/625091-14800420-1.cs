    var lines = File.ReadLines(inputFilename);
    var table = lines.Select(line => line.Split(','));
    var groups = table.GroupBy(columns => columns[1]);
    var output = groups.Select(g => g.Key + " " + string.Join(",", g.Select(columns=>columns[0])));
    File.WriteAllLines(outputFilename, output);
