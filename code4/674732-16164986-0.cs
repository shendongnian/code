    List<string> fileLines = new List<string>();
    using (var reader = new StreamReader(fileName))
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
           fileLines.Add(line);
        }
    }
