    var myObjects = (from m in db.MyObjects
                      group m by m.Name into grouped
                      select new MyObjectWithCount
                      {
                          Name = grouped.Key,
                          MatchingObjects = grouped.ToList()
                      }).AsQueryable();
