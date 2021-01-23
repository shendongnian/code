    var adjustments = DAL.GetAdjustmentsInDateRange(Start, End);
    // Get all unique dates in time span
    IEnumerable<DateTime> dates = GetAllDates(Start, End); 
    var query = (from date in dates
                    join adjustment in adjustments
                        on date.Date equals adjustment.Created.Date into a
                    from adjustment in a.DefaultIfEmpty()
                    select new {date.Date, adjustment}
                    ).GroupBy(i=>i.Date).OrderBy(g=>g.Key);
