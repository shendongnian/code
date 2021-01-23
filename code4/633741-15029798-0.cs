    var groups = list.GroupBy(l => l.Id)
                     .Select(g => new {
                                          Id = g.Key, 
                                          GoodSum = g.Sum(i=>i.Good), 
                                          TotalSum= g.Sum(i=>i.Total),
                                          Perc = (double) g.Sum(i=>i.Good) / g.Sum(i=>i.Total)
                                      }
                            );
     var average = groups.Average(g=>g.Perc);
