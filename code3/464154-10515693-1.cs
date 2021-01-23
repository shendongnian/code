    private IEnumerable<int> constructSetFromBits(int i)
    {
        int n = 0;
        for (; i != 0; i /= 2)
        {
            if ((i & 1) != 0)
                yield return n;
            n++;
        }
    }
    List<string> allValues = new List<string>()
            { "A1", "A2", "A3", "B1", "B2", "C1" };
    public IEnumerable<string> produceList()
    {
        for (int i = 0; i < (1 << allValues.Count); i++)
        {
            yield return
                string.Join(" ", constructSetFromBits(i).Select(n => allValues[n]));
        }
    }
    
