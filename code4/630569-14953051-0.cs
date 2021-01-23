    public string Format(IEnumerable<int> input)
    {
        var nodes = new List<Tuple<int, int>>();
        
        var previous = -1;
        var start = -1;
        
        foreach(var i in input)
        {
            if(start == -1)
                start = i;
            else if(previous + 1 != i)
            {
                nodes.Add(Tuple.Create(start, previous));
                start = i;
            }
    
            previous = i;
        }
        
        if(start != -1)
            nodes.Add(Tuple.Create(start, previous));
    
        return string.Join(", ",
                           nodes.Select(x => (x.Item1 == x.Item2) ?
                                              x.Item1.ToString() :
                                              string.Format("{0}-{1}",
                                                            x.Item1, x.Item2)));
    }
