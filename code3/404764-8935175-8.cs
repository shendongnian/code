    IEnumerable<IGrouping<TransactionGroup, Transaction>> groupTransaction;
    var period = (Period)Enum.Parse(typeof(Period), record.Period);
    switch (period)
    {
        case Period.Monthly:
            groupTransaction = transactions.GroupBy(x => new TransactionGroup
              {
                Month = x.TransactionDate.Month, 
                Year = x.TransactionDate.Year 
              });
            break;
        case Period.Yearly:
            groupTransaction = transactions.GroupBy(x => new TransactionGroup
              {                 
                Month = 0, 
                Year = x.TransactionDate.Year 
              });
            break;
        default:
            break;
    }
