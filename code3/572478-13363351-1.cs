     items.GroupBy(x => x.Size)
                    .Select(y =>
                            new
                                {
                                    Size = y.Key,
                                    Details = y.SelectMany(x => x.Details)
                                                .GroupBy(x => x.Key)
                                                .Select(x => new
                                                                 {
                                                                     Key = x.Key,
                                                                     Average = x.Average(c => c.Value),
                                                                     Sum = x.Sum(c => c.Value)
                                                                 })
                                });
