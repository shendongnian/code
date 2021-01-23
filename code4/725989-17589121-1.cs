    var groupedResults = results.SelectMany(v => v.Split(','))
                                .GroupBy(n = >n)
                                .Select((item, index) => 
                                         new {
                                            name = String.Format("{0}) {1}", index+1, 
                                            count = n.Count()
                                         })
                                .ToList();
