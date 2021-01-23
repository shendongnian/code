    foreach(string ln in lineList)
    {
          blockList = ln.Trim().Split(space).ToList();
          parameters.Add(blockList);
    }
