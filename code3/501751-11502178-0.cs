    var totalPlanned = 0;
    var totalRealized = 0;
    var result = stores.Where(s => s.StoreName.Equals("My Store 1"))
                       .Select(s => {
                            totalPlanned += s.PlannedSales;
                            totalRealized += s.RealizedSales;
                            return new Store(){
                               MonthYear = s.SalesDate.ToString("MM - yyyy"),
                               PlannedSales = totalPlanned,
                               RealizedSales = totalRealized
                                  
                            };
                        });
