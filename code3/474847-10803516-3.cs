    public int GetNumber(int value)
    {
        //initialize a dictionary to hold pairs of numbers
        var ranges = new Dictionary<int, int>
        {
            { 25, 250 },
            { 50, 500 },
            { 75, 750 }
        };
        //sort the dictionary in descending order and return the first value
        //that satisfies the condition
        return ranges.OrderByDescending(p => p.Key)
            .FirstOrDefault(p => value >= p.Key).Value;
    }
