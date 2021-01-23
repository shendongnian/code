    private IEnumerable<BulkProcessorResult> GetProccessResults(List<Foo> Foos)
    {
      var listOfFooLists = CreateListOfFooLists(Foos);
      return listOfFooLists.AsParallel()
                           .SelectMany(FooList => FooList)
                           .Select(Foo =>
                                new BulProcessorResult {
                                   ClaimStatusId = (int)_processor.Process(Foo),
                                   Property1 = Foo.Property1
                                }).ToList();
    }
