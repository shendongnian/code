    var counts = dbContext.CountMany(db => new 
                                           {
                                               table1Count = db.Table1.Count(),
                                               table2Count = db.Table2.Count()
                                               //etc.
                                           });
