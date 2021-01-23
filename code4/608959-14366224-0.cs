    context.Reviews.GroupBy(r => r.User)
                   .Select(g => new {
                                      User = g.Key,
                                      Reviews = g.Select(x => x.review)
                                                 .Distinct()
                                    })
                   .OrderByDescending(x => x.Reviews.Count)
                   .ToList();
 
