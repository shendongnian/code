    Map = docs => from doc in docs
                          select new
                          {
                              Category = doc.Category,
                              CategoryCount = 1,
                              ServiceCalls = doc,
                              ReportedDateTime
                          };
            Reduce = results => from result in results
                                group result by result.Category into g
                                select new
                                {
                                    Category = g.Key,
                                    CategoryCount = g.Count(),
                                    ServiceCalls = g.Select(i => i.ServiceCalls)
                                    ReportedDateTime = g.Max(rdt => rdt.ReportedDateTime)
                                };
