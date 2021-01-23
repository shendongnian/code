    var results = 
        dataContext.GlobalDanes
        .Where(gd => gd.intRampNr == 1)
        .GroupBy(
            gd =>
                new 
                {
                     gd.intMiesiac,
                     gd.intRok,
                })
        .Select(
            grp =>
                new 
                {
                    grp.Key.intMiesiac,
                    grp.Key.intRok,
                    In = grp.Sum(gd => gd.intIn),
                    Out = grp.Sum(gd => gd.inOut),
                });
