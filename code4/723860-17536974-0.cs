    string search = string.Empty;
    
    foreach (string line in listOfSrt)
    {
        string[] inCols = line.Split("\t");
    
        if (inCols[0].Contains(search))
        {
         Console.WriteLine(line);
        }
    }
