    var result = strings.Select((s, i) => new { s, i })
                    .GroupBy(x => x.i / 500)
                    .Select(x => x.GroupBy(y => y.s)
                                    .Select(z => new { 
                                                        Name=z.Key,
                                                        Count=z.Count()
                                                    }).ToList())
                    .ToList();
