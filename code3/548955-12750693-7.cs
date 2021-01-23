    public List<bool[]> GetOperators(int vars)
    {
        var result = new List<bool[]>();
        for (var i = 0; i < 1 << vars-1; i++)
        {
            var item = new bool[vars - 1];
            for (var j = 0; j < vars-1; j++)
            {
                item[j] = ((i >> j) & 1) != 0;
            }
            result.Add(item);
        }
        return result;
    }
