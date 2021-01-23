    foreach (var list in dblWordFreqByCluster)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string key = list[i].Key;
            list[i] = new KeyValuePair<string, double>(key, averages[key]);
        }
    }
