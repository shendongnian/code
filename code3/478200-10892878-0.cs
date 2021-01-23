    //init datetime list for log entries
    List<DateTime> logDates = new List<DateTime>();
    
    //Define regex string
    string pattern = @"(?<logDate>(\d){4}-(\d){2}-(\d){2}\s(\d){2}:(\d){2}:(\d){2})";
    Regex reg = new Regex(pattern);
    
    //read log content
    string logContent = File.ReadAllText("test.log");
    
    //run regex
    MatchCollection matches = reg.Matches(logContent);
    
    
    //iterate over matches
    foreach (Match m in matches)
    {
        DateTime logTime = DateTime.Parse(m.Groups["logDate"].Value);
        logDates.Add(logTime);
    }
    
    //show first and last entry
    Console.WriteLine("First: " + logDates.First());
    Console.WriteLine("Last: " + logDates.Last());
