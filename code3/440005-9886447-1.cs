    var trendData = 
                (from d in ExpenseItemsViewableDirect
                group d by new {
                                Year = d.Er_Approved_Date.Year, 
                                Month = d.Er_Approved_Date.Month 
                                } into g
                select new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Total = g.Sum(x => x.Item_Amount),
                    AveragePerTrans = Math.Round(g.Average(x => x.Item_Amount),2)
                }
           ).AsEnumerable()
            .Select(g=>new {
                  Period = g.Year + "-" + g.Month,
                  Total = g.Total,
                   AveragePerTrans = g.AveragePerTrans
             });
