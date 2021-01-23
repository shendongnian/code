    var myObjects = (from m in db.MyObjects
                      group m by m.Name into grouped
                      select new MyObjectWithCount
                      {
                          MyObject = grouped.Key,
                          Count = grouped.Count()
                      }).AsQueryable();
