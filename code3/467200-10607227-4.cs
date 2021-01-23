    List<MonthlySales> monthlySales = (from sale in Sales
    				        orderby sale.DateSold descending
    					    group sale by new YearMonthSold {Year = sale.DateSold.Year, Month = sale.DateSold.Month} into ds
    					    select new MonthlySales
                            {
                                DateSold = ds.Key,
                                (...)
                            })
    					   .Take(12)
    					   .ToList();
