    List<string> list = new List<string>(sourceDirInclusion.Keys.Count);
    foreach (string dir in sourceDirInclusion.Keys)
    {
        if (sourceDirInclusion[dir] == null)
            list.Add(dir);
    }
    foreach (string dir in list)
    {
        sourceDirInclusion.Remove(dir);
    }
