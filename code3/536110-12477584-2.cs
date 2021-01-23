    private int reviewPeriod = 5;
    public void Aggregate(int term)
    {
        Enumerable.Range(0, term)
            .ToList()
            .Foreach(this.AggregateYear);
    }
