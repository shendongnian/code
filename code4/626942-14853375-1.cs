    foreach(var list in dictGenSubs.Values)
    {
        for(int i = 0; i < list.Count; ++i)
            list[i] = list[i].Replace(" ", string.Empty);
    }
