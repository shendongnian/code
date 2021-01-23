    public List<bool[]> GetOperators(int vars)
    {
        var result = new List<bool[]>();
        for (var i = 0; i < 1 << vars; i++)
        {
            var item = new bool[vars];
            for (var j = 0; j < vars; j++)
            {
                item[j] = ((i >> j) & 1) != 0;
            }
            result.Add(item);
        }
        return result;
    }
