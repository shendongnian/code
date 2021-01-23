    // example variables for clarity of them in the method
    private List<Statistics> _statistics;
    private int _capacity;
    
    public void AddStatistic(Statistics statistic)
    {
        var index = _statistics.BinarySearch(statistic);
    
        if(index < 0)
        {
           index = ~index;
        }
        _statistics.Insert(insert, statistic);
    
        if(_statistics.Length > capacity)
        {
            // assuming sorted best to worst
            _statistics.RemoveAt(_statistics.Count - 1);
        }
    }
