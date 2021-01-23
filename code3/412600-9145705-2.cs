    // example variables for clarity of them in the method
    private List<Statistics> _statistics;
    private int _capacity;
    
    public void AddStatistic(Statistics statistic)
    {
        var index = _statistics.BinarySearch(statistic);
        
        // if it's not in the list, index will the negative representation
        // of where it should be if sorted.
        if(index < 0)
        {
           index = ~index;
        }
       // insert it into the correct location
        _statistics.Insert(index, statistic);
    
        if(_statistics.Length > capacity)
        {
            // assuming sorted best to worst, remove the last item
            _statistics.RemoveAt(_statistics.Count - 1);
        }
    }
