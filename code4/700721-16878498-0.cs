    string[] lines = File.ReadAllLines(path);
    var data = lines.Skip(1);
    var sorted = data.Select(line => new
                 {
                    SortKey = Int32.Parse(line.Split(',')[3]),
                    Line = line
                 })
                .OrderBy(x => x.SortKey)
                .Select(x => x.Line);
    File.WriteAllLines(@"C:\Users\sorteddata.csv", lines.Take(1).Concat(sorted));
