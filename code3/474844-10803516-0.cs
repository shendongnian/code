    public int GetNumber(int value)
    {          
        var ranges = new List<Tuple<int, int>>();
        ranges.Add(Tuple.Create<int, int>(50, 5000));
        ranges.Add(Tuple.Create<int, int>(100, 10000));
        ranges.Add(Tuple.Create<int, int>(150, 15000));
        ranges.OrderByDescending(x => x.Item1);
    
        for (int x = 0; x < ranges.Count; x++)
        {
            if (value >= ranges[x].Item1)
            {
                return ranges[x].Item2;
            }
        }
    
        return 0;
    }
