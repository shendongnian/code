    IQueryable<Entry> GetThingsThatBeginWithA(String[] prefixes)
    {
        var predicate = PredicateBuilder.False<Entry>();
        foreach (String prefix in prefixes)
            predicate = predicate.Or(p => p.FirstName.StartsWith(prefix));
        return database.Entries.Where(predicate);
    }
