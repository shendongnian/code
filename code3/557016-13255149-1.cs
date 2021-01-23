    public List<Transaction> GetTransactions(DateTime startDate, DateTime endDate)
    {
       var query = (from t in Repository.Transaction       
           where t.StartDate >= startDate
                 && t.EndDate < endDate)
        select new
        {
           OriginalTransaction = t,
           CurrentMaxRevisionNumber = Repository.Transaction.
                                            Where(t1 => t1.TransactionId == t.TransactionId).
                                            Max(t1 => t1.RevisionNumber);
        }).ToList();
    
        foreach(var item in list)
        {
           item.OriginalTransaction.CurrentMaxRevisionNumber = item.CurrentMaxRevisionNumber;
        }
    
        return list.Select(items => items.OriginalTransaction).ToList();
    }
