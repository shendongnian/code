    var result = indexList
                .Select(m => m.Split(','))
                .Select(sl => new
                                  {
                                      text = sl[0],
                                      dt = new DateTime(Convert.ToInt32(sl[1].Substring(4, 4)),
                                                        Convert.ToInt32(sl[1].Substring(2, 2)),
                                                        Convert.ToInt32(sl[1].Substring(0, 2)))
                                  })
                .GroupBy(x => x.text)
                .Select(g => new
                                 {
                                     text = g.Key,
                                     maxDate = g.Max(x => x.dt)
                                 });
