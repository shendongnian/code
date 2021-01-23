    public Lazy<List<string>> LazyCodesWithTransactionsBetweenDates((DateTime startInclusive, DateTime endExclusive, List<string> associatedCodes, int marketId)
    {
        return new Lazy<List<string>>(CodesWithTransactionsBetweenDates(startInclusive, endExclusive, associatedCodes, marketId));
    }
    private List<string> CodesWithTransactionsBetweenDates(DateTime startInclusive, DateTime endExclusive, List<string> associatedCodes, int marketId)
    {
        using (var context = new MarketPlaceEntities())
        {
            return (from transactions in context.Transactions
                               where
                                associatedCodes.Contains(transactions.User.Code) &&
                                transactions.MarketId == marketId &&
                                transactions.Date >= startInclusive &&
                                transactions.Date < endExclusive
                               group transactions by transactions.User.Code into uniqueIds
                               select uniqueIds.Key).ToList<string>();
        }
    }
