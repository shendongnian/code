    var keyWords = new[] { "Keyword1", "Keyword2", "Keyword3" };
    var allDotFiles = Directory.EnumerateFiles(folder, "*.dot", SearchOption.AllDirectories);
    var allTxtFiles = Directory.EnumerateFiles(folder, "*.txt", SearchOption.AllDirectories);
    var allFiles = allDotFiles.Concat(allTxtFiles);
    var allMatches = from fn in allFiles
                     from line in File.ReadLines(fn).Select((item, index) => new { LineNumber = index, Line = item})
                     from kw in keyWords
                     where line.Line.Contains(kw)
                     select new
                     {
                         File = fn,
                         Line = line.Line,
                         LineNumber = line.LineNumber,
                         Keyword = kw
                     };
    foreach (var matchInfo in allMatches)
        Console.WriteLine("File => {0} Line => {1} Keyword => {2} Line Number => {3}"
            , matchInfo.File, matchInfo.Line, matchInfo.Keyword, matchInfo.LineNumber);
