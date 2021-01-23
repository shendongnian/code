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
           
    **EDIT!!!**
    (from u in db.Users
    join a in db.Adjusters
    on u.id equals a.userID
    join s in db.AdminAdjusterStatus
    on a.id equals s.adjusterID
    where u.userType.ToLower() == "adjuster"
    && s.status.ToLower() == "approved"
    
    && s.statusDate == GetMaxStatusDate(db.AdminAdjusterStatus.ToList(), s.AdjusterID)
    
    select new AdjusterProfileStatusItem
    {
       user = u,
       adjuster = a
    })
    private DateTime GetMaxStatusDate(List<AdminAdjusterStatus> statuses, int adjusterId)
    {
         return (from a in statuses
                 where a.AdjusterId == adjusterId
                 group a by a.AdjusterId into values
                 select values.Max(x => x.statusDate)).FirstOrDefault();
    }
