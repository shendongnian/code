    var groups = from s in series
      let groupKey = new DateTime(s.timestamp.Year, s.timestamp.Month, s.timestamp.Day, s.timestamp.Hour, 0, 0)
      group s by groupKey into g select new
                                          {
                                            TimeStamp = g.Key,
                                            Value = g.Average(a=>a.value)
                                          };
