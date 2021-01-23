    string text = "$gender(he|she|it|alien)";
    string pattern = @"\$(\w+)\(([\w\|]*)\)";
    Match match = Regex.Match(text, pattern);
    
    string varName = match.Groups[1].Value;
    string[] values = match.Groups[2].Value.Split('|');
    
    Console.WriteLine(varName + ": ");
    foreach (string value in values)
    {
        Console.WriteLine("  " + value);
    }
