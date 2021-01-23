    var query =
      from a in 
        (from x in DbContext.TableA
         where x.ID == 100 
         select x)
      join b in
        (from x in DbContext.TableA
         where x.ID == 100
         group x by x.Name into x
         select new
         {
           Name = x.Key,
           AnotherId = x.Max(o => o.AnotherId),
         })
      on new { a.Name, a.AnotherId } equals new { b.Name, b.AnotherId }
      select a;
