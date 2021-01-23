    var data = context.Posts.Group(p => p.Type)
                            .Select(g => new { 
                                              Type = g.Key, 
                                              Date = g.OrderByDescending(p => p.Date)
                                                      .FirstOrDefault()
                                             }
                   
