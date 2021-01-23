    var firstQuery = myTable.Select(p => new { p.ID, ParentID = p.ParentID ?? p.ID, p.CreatedDate })
                                             .GroupBy( p => p.ParentID).Select( q => new
                                             {
                                                el = q.OrderByDescending( k => k.CreatedDate).Take(1)
                                             }).SelectMany(t => t.el);
            var result = dc.TabellaId_ParentId.Where(p => test.Select(q => q.ID).Contains(p.ID));
