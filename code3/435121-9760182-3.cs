    public IEnumerable<Int32> GetAllId()
    {
        var q1 = dict1.Values.Select(g => g.GetId());
        var q2 = dict2.Values.Select(g => g.GetId());
        var q3 = dict3.Values.Select(g => g.GetId());
    
        return q1.Concat(q2)
                 .Concat(q3)
                 .SelectMany(x => x);
    }
