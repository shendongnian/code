    var result2 = db.Visits.GroupBy(v => v.VisitID)
                .Select(g => new
                        {
                            VisitId = g.Key,
                            TotalTime =
                        g.OrderBy(v => v.ActionID).Last().EndTime.Subtract(g.OrderBy(v => v.ActionID).First().StartTime).Days
                        });
