    var myObjects = (from m in db.MyObjects
                              group m by new {m.Name, m.AnyOtherProperty, ...} into grouped
                              select new MyObjectWithCount()
                              {
                                  MyObject = grouped.FirstOrDefault(),
                                  Count = grouped.Count()
                              });
