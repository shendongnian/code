                                      select new
                                      {
                                          Key = g.Key,
                                          Cnt = g.Count(),
                                          Min = g.Min(v => v.Substring(11, 4)),
                                          Max = g.Max(v => v.Substring(11, 4))
                                      };
