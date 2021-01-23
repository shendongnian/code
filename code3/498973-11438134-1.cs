    private List<Bar> asyncMethod(CancellationToken token)
    {
        List<Bar> allResults = new List<Bar>();
        
        foreach(var processor in this.processors)
        {
            Task.Factory.StartNew<IEnumerable<Bar>>(() => 
            {     
                processor.Provide(param);
            }, atp).ContinueWith( cont => { allResults.AddRange(cont.Result) }); 
        
            // Cancellation requested from UI Thread.
            if (token.IsCancellationRequested)
                token.ThrowIfCancellationRequested();
        }
        return allResults;
    }
    
