    public IList<int> FindValues(int row, int col)
    {
        myDictionary
            .Where(item => MatchKey(item.Key, row, col))
            .Select(item => item.Value)
            .ToList();
    }
    public bool MatchKey(string key, int row, int col)
    {
        var splitKey = key.Split();
        return splitKey[1] == row.ToString() && splitKey[2] == col.ToString();
        // or match the key according to your logic
    }
