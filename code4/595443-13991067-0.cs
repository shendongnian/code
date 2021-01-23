    String []lines = System.IO.File.ReadAllLines(path);
    
    List<string> yourLinesTrimed = new List<string>;
    foreach (String line in lines)
    {
            yourLinesTrimed.Add(line.Trim());
    }
