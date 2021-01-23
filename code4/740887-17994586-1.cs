    (from a in dbContext.TableA
    join b in dbContext.TableB on a.IdB equals b.IdB into bLeft
    from bTbl in bLeft.DefaultIfEmpty()
    select new
    {
        IdBTemp = bTbl == null ? (int?)null : bTbl.IdB,
        IdATemp = a.IdA
    }.AsEnumerable().Select(row => new DynamicClassModel()
    {
        // Stuff here (convertion to string, concatanations and other stuff)
    });
