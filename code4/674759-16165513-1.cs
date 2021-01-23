    DateTime fromDate = new DateTime(2011, 1, 1);
    DateTime toDate = new DateTime(2011, 1, 1);
    var query = from p in db.Payments
                where p.Type == 1 && p.Position == 1 && 
                p.Date >= fromDate && p.Date <= toDate
                group p by p.ApplicationNo into g
                select new {
                     ApplicationNo = g.Key,
                     CNT = g.Count(),
                     AMNT = g.Sum(x => x.Amount)
               };
