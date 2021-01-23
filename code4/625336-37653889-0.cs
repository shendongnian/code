    [TestMethod]
    public void CustomDistinctTest()
    {
        // Generate some sample of domain objects
        var listOfDomainObjects = Enumerable
                                    .Range(10, 10)
                                    .SelectMany(x => 
                                        Enumerable
                                        .Range(15, 10)
                                        .Select(y => new SomeClass { SomeText = x.ToString(), SomeInt = x + y }))
                                    .ToList();
        var uniqueStringsByUsingGroupBy = listOfDomainObjects
                                        .GroupBy(x => x.SomeText)
                                        .Select(x => x.FirstOrDefault())
                                        .ToList();
        var uniqueStringsByCustomExtension = listOfDomainObjects.DistinctBy(x => x.SomeText).ToList();
        var uniqueIntsByCustomExtension = listOfDomainObjects.DistinctBy(x => x.SomeInt).ToList();
        var uniqueStrings = listOfDomainObjects
                                .Distinct(new EqualityComparerAdapter<SomeClass, string>(x => x.SomeText))
                                .OrderBy(x=>x.SomeText)
                                .ToList();
        var uniqueInts = listOfDomainObjects
                                .Distinct(new EqualityComparerAdapter<SomeClass, int>(x => x.SomeInt))
                                .OrderBy(x => x.SomeInt)
                                .ToList();
    }
