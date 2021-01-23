    IEnumerable<IGrouping<MyModel, SourceType>> groupTransaction = null;
    DollarCapPeriod dollarCapPeriod = (DollarCapPeriod)Enum.Parse(typeof(DollarCapPeriod), reward.DollarCapPeriod);
    switch (dollarCapPeriod)
    {
        case DollarCapPeriod.Monthly:
            groupTransaction = filterdTransactions.GroupBy(x => new MyModel { x.TransactionDate.Month, x.TransactionDate.Year });
            break;
        case DollarCapPeriod.Yearly:
            break;
        default:
            break;
    }
