    var result = db.Visits.GroupBy(v => v.VisitID)
                   .Select(g => new {
                             VisitId = g.Key, 
                             TotalTime = g.Max(v => v.EndTime) - g.Min(v => v.StartTime)
                          });
