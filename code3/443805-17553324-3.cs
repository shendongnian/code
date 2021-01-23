    [ArrayInput("id", Separator = ';')]
    public IEnumerable<Measure> Get(int[] id)
    {
        return id.Select(i => GetData(i));
    }
