    var groupedOccurrences = 
       (from o in db.Occurrences.Include(o => o.Employee)
        where o.OccurrenceDate >= beginDate && o.OccurrenceDate <= endDate
        group o by new {o.EmployeeID, o.Points} into g
        select new { Name = g.Key.EmployeeID, Total = g.Sum(o => o.Points)}
       ).AsEnumerable();
        
    var model = groupedOccurrences.Select(item => new PtoTracker.Occurrence { 
                             Name = item.Name,
                             Total = item.Total });
