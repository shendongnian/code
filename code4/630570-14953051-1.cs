    public string Format(IEnumerable<int> input)
    {
        var result = string.Empty;
        
        var previous = -1;
        var start = -1;
        var first = true;
        
        foreach(var i in input)
        {
            if(start == -1)
                start = i;
            else if(previous + 1 != i)
            {
                result += FormatRange(start, previous, first);
                first = false;
                start = i;
            }
    
            previous = i;
        }
        
        if(start != -1)
            result += FormatRange(start, previous, first);
    
        return result;
    }
    public string FormatRange(int start, int end, bool isFirst)
    {
        var result = string.Empty;
        if(!isFirst)
            result += ", ";
        if(start == end)
            result += start;
        else
            result += string.Format("{0}-{1}", start, end);
        return result;
    }
