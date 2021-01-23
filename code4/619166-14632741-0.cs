    string origFileContents = File.ReadAllText(path);
    
    // Changed cleanFileContents to a StringBuilder for performance reasons
    var cleanFileContents = New StringBuilder( origFileContents.Replace("\n", "").Replace("\r", "") );
    
    Regex regex = new Regex(@"([0-9]{4}-[0-9]{2}-[0-9]{2}_[0-9a-zA-Z]*--)", RegexOptions.Singleline);
    MatchCollection matches = regex.Matches(cleanFileContents.ToString());
    
    int counter = 0;
    
    foreach (Match match in matches)
    {
        cleanFileContents.Insert(match.Index + Environment.NewLine.Length * counter, Environment.NewLine);
        counter++;
    }
    var result = cleanFileContents.ToString()
