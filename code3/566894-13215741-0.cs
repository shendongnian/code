    public static Dictionary<int, int> GetNormalised(int[] data)
    {
        var normalised = data.Select((value, index) => new { value, index })
            .GroupBy(p => p.value, p => p.index)
            .Where(p => p.Key != 0)
            .OrderBy(p => p.Key)
            .ToDictionary(p => p.Key, p => p.Min());
        return normalised;
    }
  
