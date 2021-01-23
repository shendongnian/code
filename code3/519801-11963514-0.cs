    private static IQueryable<Investment> PerformanceSearch<TMember>(
                                  IQueryable<Investment> investments, 
                                  Func<Performance,TMember> SearchColumn, 
                                  TMember minValue, 
                                  TMember maxValue)
    {
        var entity = ExtendedEntities.Current;
        investments = from inv in entity.Investments 
            join perfromance in entity.Performances on inv.InvestmentID equals perfromance.InvestmentID
            where SearchColumn(perfromance) >= minValue && SearchColumn(perfromance) <= maxValue
        return investments;
    }
