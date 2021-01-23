    var regex = new Regex(@"Command\s+:\s+Update");
    List<string> itemsToOutput = null;
    foreach(var line in File.ReadLines("C:\\test.txt"))
    {
        if (regex.IsMatch(line))
        {
            itemsToOutput = new List<string>();
            continue;
        }
    
        if (itemsToOutput != null)
        {
            itemsToOutput.Add(line);
        }
    }
