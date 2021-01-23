    using (TransactionScope curentScope = new TransactionScope())
    {
        List<Query> newQueries = new List<Query>(); 
        Query newQuery = new Query();
        newQueries.Add(newQuery);
        foreach (long workItemId in workItemID)
        {
            newQuery = new Query();
            newQueries.Add(newQuery);
            ...
            curentScope.Complete();
            success = true;           
        }
    }
    entityCollection.SaveChanges(true);
    var queryIDs = newQueries.Select(q => q.QueryID);
