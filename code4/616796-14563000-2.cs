    string header = "  PTC       CUR                 TAX           FARE BASIS";
    bool takeNextLine = false;
    foreach (string line in File.ReadLines(@"C:\FareSearchRegex.txt"))
    {
        if (line.StartsWith(header))
            takeNextLine = true;
        else if (takeNextLine)
        {
            var tokens = line.Split(new[] { @"   " }, StringSplitOptions.RemoveEmptyEntries);
            dt.Rows.Add().ItemArray = tokens.Where((t, i) => i != 2).ToArray();
            takeNextLine = false;
        }
    }
