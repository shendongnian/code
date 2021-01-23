    var result = dict.SelectMany(p => p.Value
                                        .Select(s => new
                                        {
                                            Key = p.Key,
                                            Value = s
                                        }))
                        .GroupBy(a => a.Value)
                        .ToDictionary(g => g.Key,
                                    g => g.Select(a => a.Key)
                                            .ToList());
