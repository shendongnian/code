    ConcurrentDictionary<string, int> personNameToIdMap = new ConcurrentDictionary<string, int>();
    Parallel.ForEach(allPersons, p =>
    {
        int outputId = personNameToIdMap.GetOrAdd(p.Name, name => doExpensiveLookup(p.Name));
        // ...
        p.Id = outputId;
    }
