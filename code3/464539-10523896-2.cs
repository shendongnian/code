    var result = dbContext.VisitDates
                          .GroupBy(x => x.VisitMeDate.Date)
                          .Where(g => g.Count() == 3)
                          .Select(g => g.ToList())
                          .ToList();
