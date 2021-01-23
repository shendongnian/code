    void Run()
    {
        IEnumerable<IEnumerable<YourType>> inputs = GetYourObjects();
        Func<IEnumerable<YourType>, IEnumerable<YourType>> query = i => 
           i.Where(x => x.FirstName.StartsWith("d") && x.IsRemoved == false)
            .Select(x => x.FirstName)
            .OrderBy(x => x.FirstName);
        var results = QueryMultiple(inputs, query);
    }
