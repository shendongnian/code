    from t in TimeEntries
    group t by new {t.WeekEnding, t.UserId } into g
    let firstT = t.First()
    select new
    {
      WE = g.Key.WeekEnding,
      User = g.Key.UserId
      HoursTotal = g.Sum(x => x.Hours)
      DisplayName = firstT.User.DisplayName
    }
    from t in TimeEntries
    group t by new {t.WeekEnding, t.UserId } into g
    let user = (from u in Users where u.UserId == g.Key.UserId select u).Single()
    select new
    {
      WE = g.Key.WeekEnding,
      User = g.Key.UserId
      HoursTotal = g.Sum(x => x.Hours)
      DisplayName = user.DisplayName
    }
