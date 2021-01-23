    var Collection = from R in DbContext.TableA  
    join G in (DbContext.TableA
                          .Where(r => r.Id == 100)
                          .GroupBy(r => r.Name)
                          .Select(g => new { Name = g.Key , AnotherId = g.Max(o => o.AnotherId) }))  
    on new { R.Name, R.AnotherId } equals new { G.Name, G.AnotherId }  
    where R.Id == 100  
    select R; 
