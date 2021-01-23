    List<BusinessPlanningElement> MileStoneSales = (from sale in productSales
                      group sale by sale.DateSold into ds
                      select new BusinessPlanningElements
                      {
                          DateSold = ds.Key,
                          TotalSales = ds.Sum(it => it.TotalProductCut.HasValue ? it.TotalProductCut.Value : 0),
                      }).OrderBy(s => s.DateSold).ToList();
    decimal accumulatedSales = 0;
    BusinessPlanningElement bpe = MileStoneSales
                                    .SkipWhile(mss => {
                                            accumulatedSales += mss.TotalSales;
                                            return accumulatedSales < milestone;
                                     })
                                    .FirstOrDefault();
