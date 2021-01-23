    var result = (from x in list
                  from y in x.MyClasses2
                  from z in y.MyClasses3
                  where z.Property1
                  group new { y, z } by x.Id into g1
                  select new MyClass1
                  {
                      Id = g1.Key,
                      MyClasses2 = (from p in g1
                                    group p.z by p.y.Id into g2
                                    select new MyClass2
                                    {
                                        Id = g2.Key,
                                        MyClasses3 = (from r in g2
                                                      select new MyClass3
                                                      {
                                                          Id = r.Id,
                                                          Property1 = r.Property1
                                                      }).ToList()
                                    }).ToList()
                  }).ToList();
