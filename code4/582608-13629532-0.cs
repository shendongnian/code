    class Range
    {
        public int? Start { get; set; }
        public int? End { get; set; }
    }
    private static IEnumerable<Range> getAdjacentRanges(IEnumerable<int> nums)
    {
        var ranges = new List<Range>();
        if (!nums.Any())
            return ranges;
        var ordered = nums.OrderBy(i => i);
        int lowest = ordered.First();
        ranges.Add(new Range { Start = lowest });
        int last = lowest;
        Range lastRange = null;
        foreach (int current in ordered)
        {
            lastRange = ranges[ranges.Count - 1];
            if (current > last + 1)
            {
                lastRange.End = last;
                ranges.Add(new Range { Start = current });
            }
            last = current;
        }
      
        return ranges;
    }
