    var preModel = data.GroupBy(x => x.Scheme_Name)
                       .Select(x => new {
                                          Scheme_Name = x.Key, 
                                          Max = x.Max(m => m.ReInvest_Nav), 
                                          Data = x
                                        })
                       .SelectMany(x => x.Data.Select(y => new {
                                           y.Scheme_Name, 
                                           y.Date, 
                                           y.ReInvest_Nav, 
                                           Rebased = y.ReInvest_Nav / x.Max * 100
                                         }))
                       .OrderBy(x => x.Scheme_Name)
                       .ThenBy(x => x.Date)
                       .ToList();
