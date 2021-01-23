    var result = (from l in repoA.GetAll()
                               where   l.Created >= System.DateTime.Now.AddYears(-1) 
                               group l by l.Created.Month into groups
                               orderby groups.Key ascending
                               select new
                                  {
                                      Month = groups.Key,
                                      Assigned = groups.Where(g => g.Category == "Assigned").Count(),
                                      Deassigned = groups.Where(g => g.Category == "DeAssigned").Count(),
                                      LogIn = groups.Where(g => g.Category == "LogIn").Count()
                                  });
