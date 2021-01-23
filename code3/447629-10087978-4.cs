    var groups = context.Essais.GroupBy(p => p.BoitierNumber)
                    .Select(g => new 
                                    { 
                                      GroupName = g.Key, 
                                      Members = g.OrderBy(m=>m.Id)
                                    });
