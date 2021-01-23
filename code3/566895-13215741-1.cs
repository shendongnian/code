    public static int GetNearest(Dictionary<int, int> normalised, int value)
    {
        var res = normalised.Where(p => p.Key <= value)
            .OrderBy(p => value - p.Key)
            .Select(p => (int?)p.Value)
            .FirstOrDefault();
    
        if (res == null)
        {
            throw new ArgumentOutOfRangeException("value", "Not found");
        }
                
        return res.Value;
    }
