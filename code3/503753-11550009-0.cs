    using (var db = new FundResearchContext(null))
    {
        var query = from a in db.As select new 
                    {
                        // ...
                        bs = (from b in db.Bs 
                              where b.AnId == a.AnotherId 
                              select b)
                             .ToList()
                    };
        // ...
    }
