    var firstDates = db.DeviceLogs.GroupBy(d => d.UserId).ToDictionary(
        g => g.Key,
        g => g.OrderBy(d => d.LogDate).First().LogDate);
    db.DeviceLogs.GroupBy(g => new
      {
        Math.Floor(SqlMethods.DateDiffMinute(firstDates[d.UserId], g.LogDate) / 5),
        g.UserID
      }).Select(s => s.OrderBy(s => s.LogDate).First());
