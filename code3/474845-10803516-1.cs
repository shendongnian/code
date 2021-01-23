    public int GetNumber(int value)
    {
        var ranges = new Dictionary<int, int>
        {
            { 25, 250 },
            { 50, 500 },
            { 75, 750 }
        };
        ranges.OrderByDescending(x => x.Key);
        foreach (int key in ranges.Keys)
        {
            if (value >= key)
            {
                return ranges[key];
            }
        }
        return 0;
    }
