    var result = db.Visits.GroupBy(v => v.VisitID)
                .Select(g => new
                        {
                            VisitId = g.Key,
                            TotalTime = g.Max(v => v.EndTime).Subtract(g.Min(v => v.StartTime)).Days
                        });
