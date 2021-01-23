    var query = from b in Bookings
                where b.Date >= dateFrom && b.Date <= dateTo
                group b by new { b.Group, b.Type, b.Status } into g
                select new GroupedLine()
                {
                    Group = g.Key.Group,
                    Type = g.Key.Type,
                    Status = g.Key.Status,
                    WeeklyStats = (from b in g
                                    let startOfWeek = GetFirstDateOfWeek(b.Date)
                                    group b by startOfWeek into weekGroup
                                    orderby weekGroup.Key
                                    select new WeeklyStat() 
                                    {
                                        WeekStart = weekGroup.Key,
                                        Count = weekGroup.Count(),
                                        Sum = weekGroup.Sum(x => x.Price)
    
                                    }).ToList()
                };
