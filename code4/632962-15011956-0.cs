    public IEnumerable<string> CodesWithTransactionsBetweenDates(
             DateTime startInclusive, DateTime endExclusive, 
             List<string> associatedCodes, int marketId)
    {
        // do not use local list
        
        using (var context = new MarketPlaceEntities())
        {
            return from transactions in context.Transactions
                    where associatedCodes.Contains(transactions.User.Code) &&
                          transactions.MarketId == marketId &&
                          transactions.Date >= startInclusive &&
                          transactions.Date < endExclusive
                          group transactions by transactions.User.Code into uniqueIds
                          select uniqueIds.Key; // do not create anonymous object
        }
    }
