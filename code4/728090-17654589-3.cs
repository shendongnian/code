    // populate our class with the time period we are interested in
    var startDate = saleList.Min (x => x.ActivationDate);
    var endDate = saleList.Max (x => x.EndDate);
    
    List<SaleMonth> salesReport = new List<SaleMonth>();
    for(var i = new DateTime(startDate.Year, startDate.Month, 1); 
        i <= new DateTime(endDate.Year, endDate.Month, 1);
        i = i.AddMonths(1))
    {
        salesReport.Add(new SaleMonth { MonthYear = i });
    }
    
    // loop through each Month-Year
    foreach(var sr in salesReport)
    {
        // get all the sales that happen in thie month
        var sales = from s in saleList
            where sr.MonthYear >= new DateTime(s.ActivationDate.Year, 
                                      s.ActivationDate.Month, 1)
            where sr.MonthYear <= new DateTime(s.EndDate.Year, 
                                      s.EndDate.Month, 1)
        select s;
        
        // calculate the number of days the sale spans for just this month
        sr.DaysMonth = sales.Sum (x => 
            (x.EndDate < sr.MonthYear.AddMonths(1) ? 
                x.EndDate.Day : sr.MonthYear.AddMonths(1).AddDays(-1).Day) -
                (sr.MonthYear > x.ActivationDate ? sr.MonthYear.Day : x.ActivationDate.Day)
        );
        
        // how many sales occur over the entire month
        sr.FullMonth = sales.Where (x => x.ActivationDate <= sr.MonthYear && 
                                         sr.MonthYear.AddMonths(1) < x.EndDate).Count ();
    }
