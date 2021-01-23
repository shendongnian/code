    var collection = DbContext.TableA
                              .Where(t1 => t1.Id == 100)
                              .Join(DbContext.TableA
                                    .Where(t2 => t2.Id == 100)
                                    .GroupBy(t2 => t2.Name)
                                    .Select(group => new{Name = group.Key.Name, 
                                                          AnotherId = group.Max(e => e.AnotherId)})
                                     ),
                                     t1 => new{t1.Name, t1.AnotherId} ,
                                     t2 => new{t2.Name, t2.AnotherId},
                                     (t1, t2) => t1);
