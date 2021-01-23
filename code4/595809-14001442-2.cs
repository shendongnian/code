    //Figure out the day you want in advance
    var sevenDaysAgo = DateTime.Now.Date.AddDays(-7);
    foreach (var user in users)
    {
        //Don't try to get just the date part in the query
        var days = context.Attendances
                          .Where(x => x.UserKey == user.Key && x.LoginDate > sevenDaysAgo)
                          .Select(x => x.LoginDate)
                          //Collapse the set of login DateTime objects to a list
                          .ToList()
                          //Now that we're doing LinqToObjects, get just the date
                          .Select(x => x.Date)
                          //Get the distinct dates
                          .Distinct();
        int count = days.Count();
        _attendanceTable.Rows.Add(user.Key, user.Value, count);
    }
