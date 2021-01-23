    public IEnumerable<int> GetData()
    {
        return Enumerable.Range(0, 100000000);
    }
    
    void Main()
    {
        var optimizer = new DataFlowOptimizer<int>(GetData());
        
        foreach(var batch in optimizer.GetBatch())
        {
            string.Format("Length: {0} Rate {1}", optimizer.BatchLength, optimizer.Rate).Dump();
        }
    }
