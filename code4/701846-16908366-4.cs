    while (list.Count > 0)
    {
        int i = GetSmallestTestIdx(list);
        do
        {
            result.Add(list[i]);
            list.RemoveAt(i);
        }
        while ((i = GetNextTextIdx(list, result)) != -1);
    }
