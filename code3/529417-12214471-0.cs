    var sb = new StringBuilder()
    var regex = new Regex("\",\"");
    foreach(string line in textFileLines)
    {
       sb.AppendLine(regex.Replace(line , "\"|\"", 2));
    }
