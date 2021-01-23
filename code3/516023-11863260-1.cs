    var mapping = updates
        .Select(o => new { id = o.Id, parent = o.Parent}); // NOT ToList() !!
    var results = from fa in Uvw_MyTable 
                  where mapping.Contains(new { id = fa.Id, parent = fa.Parent })
                  select new { fa };
