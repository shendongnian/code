    List<int> idList = new List<int>();
    List<int?[]> valList = new List<int?[]>();
    string line;
    while (null != (line = sr.ReadLine()))
    {
        string[] lineParts = line.Split(delimiters);
        int id = Convert.ToInt32(lineParts[0]);
        idList.Add(id);
        
        int?[] vals = new int?[numTests];
        for (int i = 0; i < numTests; i++)
        {
            int parsed;
            if (!int.TryParse(lineParts[i + 1], out parsed))
                vals[i] = null;
            else
                vals[i] = parsed;
        }
        valList.Add(vals);
        line = sr.ReadLine();
    }
    childIDs = idList.ToArray();
    var values = valList.ToArray();
