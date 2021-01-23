    var results = list1.GroupBy(i => i.Name)
                       .Select(g => new
                                    {
                                        Name = g.Key,
                                        DocCount = g.Sum(i => i.DocCount)
                                    });
