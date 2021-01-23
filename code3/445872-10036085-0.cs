    public IEnumerable<int> GetNumbers(int start)
    {
        int num = start;
        while(true)
        {
            yield return num;
            num++;
        }
    }
