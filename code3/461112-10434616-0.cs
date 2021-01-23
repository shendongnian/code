    List<string[]> parsedRaw = new List<string[]>();
    parsedRaw.Add(new string[] {"test1", "test2"});
    parsedRaw.Add(new string[] { "test1", "test2", "test3" });
    int totalSize = 0;
    for (int i = 0; i < parsedRaw.Count(); i++)
    {
        int rowSize = 0;
        for (int k = 0; k < parsedRaw[i].Count(); k++)
        {
            rowSize += parsedRaw[i][k].Length;    
        }                
        totalSize += rowSize;
    }
