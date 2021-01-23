    var sums = query.GroupBy(q => 1)
                    .Select(g => new
                    {
                        PageViews = g.Sum(q => q.PageViews),
                        Visits = g.Sum(q => q.Visits),
                        // etc etc
                    })
                    .Single();
