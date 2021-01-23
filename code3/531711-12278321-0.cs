    var query1=from sn in code                                        
                                    group sn by sn.Substring(0, 10) into g
                                    select new
                                    {
                                        Key = g.Key,
                                        Cnt = g.Count(),
                                        Min = g.Min(v => v.Substring(10, 4)),
                                        Max = g.Max(v => v.Substring(10, 4))
                                    };
    var query2=from sn1 in codes
                                      group sn1 by sn1.Substring(0, 11) into g
                                      select new
                                      {
                                          Key = g.Key,
                                          Cnt = g.Count(),
                                          Min = g.Min(v => v.Substring(11, 4)),
                                          Max = g.Max(v => v.Substring(11, 4))
                                      };
    var query3= query1.Union(query2)
