    var aggrList = list
        .GroupBy(x => new { x.Name, x.Currency, x.F1, x.F2, x.F3 })
        .Select(grp => new {
                Name = grp.First().Name,
                Currency = grp.First().Currency,
                Amount = grp.Sum(x=>x.Amount),
                Date = grp.Max(x=>x.Date),
                F1 = grp.First().F1,    
                F2 = grp.First().F2,    
                F3 = grp.First().F3,    
            });
