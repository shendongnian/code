    Regex regex = new Regex(@"([0-9]{4}-[0-9]{2}-[0-9]{2}_[0-9a-zA-Z]*--)", RegexOptions.Singleline);
    StringBuilder sbAll = new StringBuilder();
    StringBuilder sbLine = new StringBuilder();
    foreach (string line in System.IO.File.ReadAllLines("path"))
    {
        sbLine.Append(line);
        MatchCollection matches = regex.Matches(line);
    
        int counter = 0;
    
        foreach (Match match in matches)
        {
            sbLine.Insert(match.Index + Environment.NewLine.Length * counter, Environment.NewLine);
            counter++;
        }
        sbAll.Append(line);
        sbLine.Clear();
    }
