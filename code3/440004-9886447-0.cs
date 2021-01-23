    var trendData = 
                from d in ExpenseItemsViewableDirect
                group d by new {
                                Year = d.Er_Approved_Date.Year, 
                                Month = d.Er_Approved_Date.Month 
                                } into g
                select new
                {
                    Period = g.Key.Year + "-" + g.Key.Month,
                    Total = g.Sum(x => x.Item_Amount),
                    AveragePerTrans = Math.Round(g.Average(x => x.Item_Amount),2)
                };
