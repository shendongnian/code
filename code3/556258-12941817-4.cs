    var weeks = Bookings.Select(b => GetFirstDateOfWeek(b.Date))
                        .Distinct().OrderBy(date => date);
    var query = from b in Bookings
                group b by new { b.Group, b.Type, b.Status } into bookingGroup
                select new GroupedLine()
                {
                   Group = bookingGroup.Key.Group,
                   Type = bookingGroup.Key.Type,
                   Status = bookingGroup.Key.Status,
                   WeeklyStats = (from w in weeks
                                  join bg in bookingGroup 
                                  on w equals GetFirstDateOfWeek(bg.Date) into weekGroup
                                  orderby w
                                  select new WeeklyStat() 
                                  {
                                      WeekStart = w,
                                      Count = weekGroup.Count(),
                                      Sum = weekGroup.Sum(b => b.Price)    
                                  }).ToList()
                };
