    var date = DateTime.Now.AddDays(-7).Date;
    var query = from e in context.Employees
                join a in context.Attendances on e.Id equals a.Id into g
                select new
                {
                    e.Id,
                    e.Name,
                    Count = g.Where(x => x.LoginDate > date)
                             .GroupBy(x = > new {
                                   x.LoginDate.Year,
                                   x.LoginDate.Month,
                                   x.LoginDate.Day 
                              }).Count()
                };
    
    foreach(var user in query)
       _attendanceTable.Rows.Add(user.Id, user.Name, user.Count);
