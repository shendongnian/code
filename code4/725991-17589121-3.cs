    var groupedResults = results.SelectMany(v => v.Split(','))
                            .GroupBy(n => n)
                            .Select((item, index) => 
                                     new {
                                        name = String.Format("{0}) {1}", index+1, item.Key),
                                        count = item.Count()
                                     })
                            .ToList();
