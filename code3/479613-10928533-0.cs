    public List<int> Get(Dictionary<ItemType, IEnumerator<int>> iterators, int n)
    {
        var result = new List<int>();
        foreach (var itor in iterators.Values)
        {
            for (var i = 0; i < n && itor.MoveNext(); i++)
            {
                result.Add(itor.Current);
            }
        }
        return result;
    }
