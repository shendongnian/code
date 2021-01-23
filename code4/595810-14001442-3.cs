    //Figure out the day you want in advance
    var sevenDaysAgo = DateTime.Now.Date.AddDays(-7);
    var results = users.Select(user => new {
         user.Key,
         user.Value,
         Count = users.Join(context.Attendances, 
                            user => user.Key,
                            attendance => attendance.UserKey,
                            (user, attendance) => attendance.LoginDate)
                      .Where(date => date > sevenDaysAgo)
                      .Select(date => date.Day)
                      .Distinct()
                      .Count()
    });
    foreach (var result in results)
    {        
        _attendanceTable.Rows.Add(result.Key, result.Value, result.Count);
    }
