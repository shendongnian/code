    public List<Transaction> GetTransactions(DateTime startDate, DateTime endDate)
    {
       var list = (from t in Repository.Transaction  
           where t.StartDate >= startDate
                 && t.EndDate < endDate)
        select t).ToList();
    
        foreach(var item in list)
        {
            item.CurrentMaxRevisionNumber = Repository.Transaction.
                                            Where(t => t.TransactionId == item.TransactionId).
                                            Max(t => t.RevisionNumber);
        }
    
        return list;
    }
