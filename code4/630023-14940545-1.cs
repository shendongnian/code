    select new // anonymous type from DB
    {
        ProfitcenterCode = tProfitcenter.Key,
        // notice there are no conversions for these sums
        TotalTransactionAmount = tProfitcenter.Sum(t => t.LocalAmount),       
        TotalTransactionAmountInEUR = tProfitcenter.Sum(t => t.AmountInEUR)
    })
    .AsEnumerable() // perform rest of work in memory
    .Select(item =>
         // construct your proper type outside of DB
    	new TransactionTotalForProfitcenter
    	{
    	    ProfitcenterCode = item.ProfitcenterCode,
    	    TotalTransactionAmount = (decimal)item.TotalTransactionAmount
    	    TotalTransactionAmountInEUR = (decimal)item.TotalTransactionAmountInEUR
    	}
    ).ToList();
