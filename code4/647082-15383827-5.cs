    from j in context.RXS_RxJobs
        .Where(x => SqlFunctions.DateDiff("wk", x.RXS_OrderDate, DateTime.Now) == 1)
    group j by new { 
        j.RXS_ACCN, 
        Date = EntityFunctions.TruncateTime(j.RXS_OrderDate).Value
    } into g
    select new OrderOverViewModel {
       Quantity = g.Count(),
       ACCN =  g.Key.RXS_ACCN,
       OrderDate = g.Key.Date 
    };
