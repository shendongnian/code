                List<User> users = new List<User>();
                users.Add(new User() { SiteId = 0, IsMod = 1, ModLimit = 3 });
                users.Add(new User() { SiteId = 1, IsMod = null, ModLimit = 2 });
                users.Add(new User() { SiteId = 1, IsMod = 1, ModLimit = 2 });
                users.Add(new User() { SiteId = 1, IsMod = 1, ModLimit = 2 });
    
                var innerSelect = users
                        .Where(o => o.IsMod != null && o.IsMod > 0)
                        .GroupBy(o => o.SiteId)
                        .Select(o => new User
                         {
                             SiteId = o.Key,
                             Counter = o.Count()
                         })
                         .ToList();
    
                var result = (from u in users
                              join s in innerSelect on u.SiteId equals s.SiteId
                              where u.SiteId == 1
                              select new
                              {
                                  u.ModLimit,
                                  NumberOfMods = s.Counter
                              })
                              .Distinct()
                              .ToList();
