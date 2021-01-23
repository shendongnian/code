    var results = db.Tests.GroupBy(t => t.name)
                          .OrderBy(g => g.Key)
                          .Select(g => new
                                  {
                                      name = g.Key,
                                      val_1 = g.Sum(x => x.val_1),
                                      val_2 = g.Sum(x => x.val_2)
                                  });
        
