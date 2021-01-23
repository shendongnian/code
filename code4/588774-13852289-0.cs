    var lines = File.ReadAllLines(load_dialog.FileName);
    int lineCount = lines.Count();
    int totalChars = 0;
    int totalPipes = 0; // number of "|" chars
    foreach (var s in lines)
    {
        var entries = s.Split('|');  // split the line into pieces (e.g. an array of "Matthew", "Walker", etc.)
        totalChars += s.Length;   // add the number of chars on this line to the total
        totalPipes = totalPipes + entries.Count() - 1; // there is always one more entry than pipes
    }
