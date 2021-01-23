    // instead of DbType your should use the type of db.enterprise
    Func<IEnumerable<DbType>, IEnumerable<DbType>> ordering= t => t; // default ordering (as it is)
    ...
    var query = (from c in ordering(db.enterprise)
                        select new { c.id, c.name, c.phone, c.email, c.type, c.city })
                        .Skip(numberOfObjectsPerPage * page).Take(numberOfObjectsPerPage);
    ...
    // in your button click method
    if (orderCB.SelectedIndex == 1)
    {
        ordering = t => t.OrderByDescending(i => i.name); 
    }
    else if (orderCB.SelectedIndex == 2)
    {
        ordering = t => t.OrderBy(i => i.id); 
    }
    ...
