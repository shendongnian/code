     var allusernames=
        ( 
        from s in db.Statistics
        where s.User.ScreenName == screenName && 
              s.CreateDate > EntityFunctions.AddDays(DateTime.Now, days)
        group s by EntityFunctions.TruncateTime(s.CreateDate) into dg
        let maxDate = dg.Max(x => x.CreateDate)
        from s2 in db.Statistics
        where s2.User.ScreenName == screenName && 
              s2.CreateDate == maxDate
        orderby s2.CreateDate
        select s2.User.UserName       // <--------
        ).ToList();
    var distinct users =
        (
            from u in users
            where allusernames.Contains(u.UserName)
            select u
        ).ToList();
     
