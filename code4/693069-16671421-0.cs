    var neworderGroupDict = (from m in KMVData.AsEnumerable()
                                                      select new
                                                      {
                                                          datakey = m.Field<string>("OrderNumber"),
                                                           datavalue = m.Field<int>("OrderGroup")
                                                      }).GroupBy(x => x.datakey).ToDictionary(g => g.Key, g => g.ToList());
