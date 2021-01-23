    public static IEnumerable<List<int>> Split(List<int> list, int delimiter)
    {
        var start = 0;
        foreach (var end in list.FindAll(x => x == delimiter).Select(splitter => list.IndexOf(splitter, start)))
        {
            yield return list.GetRange(start, end - start);
    
            start = end + 1;
        }
    
        if (start <= list.Count)
        {
            yield return list.GetRange(start, list.Count - start);
        }
    }
