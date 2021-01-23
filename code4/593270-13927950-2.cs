    var query = ent.MyTable.GroupBy(r => r.F0000 )
                           .Select(grp => new {
                               F008 = grp.Sum(r => r.F008),
                               Rows = grp // use this value for sum in switch block
                           });
