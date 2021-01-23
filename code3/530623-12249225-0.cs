    void Main()
    {
        var list = new List<string> { "a", "b", "c", "d", "e" };
        var result = GetCombinations(list, 3);
    }
    
    IEnumerable<string> GetCombinations(IEnumerable<string> items, int count)
    {
        int i = 0;
        foreach(var item in items)
        {
            if(count == 1)
                yield return item;
            else
            {
                foreach(var result in GetCombinations(items.Skip(i + 1), count - 1))
                    yield return string.Format("{0}, {1}", item, result);
            }
            
            ++i;
        }
    }
