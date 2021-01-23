    DateTime start = new DateTime(2012,09,01);
    DateTime end = new DateTime(2012,09,05);
    
    var query = Enumerable.Range(0,(end-start).Days+1)  // range of ints 
            .Select(i => start.AddDays(i))              // range of dates
            .GroupJoin(data,
                d=>d,
                d=>d.Date,
                (d,g)=>new { Date = d, 
                             Day = d.ToString("dddd"), 
                             Sales = g.Any() ? g.Sum(i=>i.Sales) : 0 
                           }
                );
