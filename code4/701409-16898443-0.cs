    private IEnumerable<BulkProcessorResult> GetProccessResults(List<Foo> Foos)
    {
        var listOfFooLists = CreateListOfFooLists(Foos);
    
        var bulkProcessorResults = new ConcurrentQueue<BulkProcessorResult>();
        Parallel.ForEach(listOfFooLists, FooList =>
        {
            foreach (var Foo in FooList)
            {
                var processClaimResult = _processor.Process(Foo);
                var bulkProcessorResult = new BulkProcessorResult()
                {
                    ClaimStatusId = (int) processClaimResult.ClaimStatusEnum,
                    Property1 = Foo.Property1
                };
                bulkProcessorResults.Enqueue(bulkProcessorResult);
            }
        }); 
    
        return bulkProcessorResults;
    }
