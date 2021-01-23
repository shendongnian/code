    var keyWords = new []{"Y","N","Y"};
    var allDotFiles = Directory.EnumerateFiles(folder, "*.dot", SearchOption.AllDirectories);
    var allTxtFiles = Directory.EnumerateFiles(folder, "*.txt", SearchOption.AllDirectories);
    var allFiles = allDotFiles.Concat(allTxtFiles);
    var allMatches = from fn in allFiles
                     from line in File.ReadLines(fn)
                     from kw in keyWords
                     where line.Contains(kw)
                     select new { 
                         File = fn,
                         Line = line,
                         Keyword = kw
                     };
    foreach (var matchInfo in allMatches)
        Console.WriteLine("File => {0} Line => {1} Keyword => {2}"
            , matchInfo.File, matchInfo.Line, matchInfo.Keyword);
