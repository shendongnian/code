        db.DeviceLogs.GroupBy(g => new
                                 {
                                     g.LogDate.Year, 
                                     g.LogDate.Month, 
                                     g.LogDate.Day, 
                                     g.LogDate.Hour, 
                                     g.LogDate.Minutes, 
                                     g.UserID
                                 })
                 .Select(s => s.OrderBy(s => s.LogDate).First());
