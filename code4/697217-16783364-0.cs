    foreach(string ln in lineList)
    {
        var trimmed = ln.Trim();
        blockList = trimmed.Split(space).ToList();
        parameters.Add(blockList);
    }
