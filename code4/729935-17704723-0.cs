    db.Users
      .Join(db.Adjusters,
      u => u.Id,
      a => a.UserId,
      (u, a) => new 
      {
           User = u,
           Adjuster = a
      })
      .Join(db.AdminAdjusterStatus,
      a => a.Adjuster.Id,
      s => s.AdjusterId,
      (a, s) => new 
      {
           User = a.User,
           Adjuster = a.Adjuster,
           AdminAdjusterStatus = s
      })
      .Where(x => x.User.userType == "adjuster"
          && x.AdminAdjusterStatus.status == "approved"
          && x.AdminAdjusterStatus.statusDate == db.AdminAdjusterStatus
                                 .Where(y => y.AdjusterId == 
                                        x.AdminAdjusterStatus.AdjusterId)
                                 .Max(z => z.statusDate))
      .Select(a => new AdjusterProfileStatusItem
      {
          user = a.User
          adjuster = a.Adjuster
      })
           
