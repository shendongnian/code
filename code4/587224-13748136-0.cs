    //Order the sales info by date. If it's already ordered then remove this.
    productSales = productSales.OrderBy(ps => ps.DateSold).ToList();
    //Compute a list of dates, with total sales up to that date
    decimal runningTotal = 0m;
    var salesRunningTotals = (from sale in productSales
                                select new
                                {
                                    DateSold = sale.DateSold,
                                    TotalSalesToDate = (runningTotal += (sale.TotalProductCut ?? 0))
                                })
                                .ToList(); 
    foreach (decimal milestone in milestones)
    {
        //Find the date we reached that milestone
        //If you're going to have a *lot* of dates you could remember the index of the last milestone
        //and start looking for the next one at that index
        var dateReached = (from rt in salesRunningTotals
                            where rt.TotalSalesToDate >= milestone
                            select rt.DateSold).FirstOrDefault();
        if (dateReached != null)
        {
            var bpe = productSales.Where(ps => ps.DateSold == dateReached).FirstOrDefault();
            if (bpe != null)
            {
                DateTime DateReached = bpe.DateSold;
                TimeSpan ts = DateReached - bpe.DateTimeSubmitted.Value;
                int NumberOfDays = ts.Days;
                //Output NumberOfDays
            }
            else
            {
                //Do Something Else
            }
        } 
    }
