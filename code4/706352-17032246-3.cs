    var users = (from u in db.Users.Include("UserLogins")
      join ul in db.UserLogins on u.UserId equals ul.UserId
      join ua in db.UserActions ON ul.UserLoginId = ua.UserLoginId
      where u.IsActive = true
      group new { ul, ua }
        by new {u.UserId} into proj)
    .AsEnumerable()  // Hydrate the query
    .Select(y=> new 
    {
        UserId = (Int32)y.Key.UserId,
        LoginDates = string.Join(",",
                                 y.Select( i => i.LoginDate
                                                 .ToString("yyyy-MM-dd")
                                         ).ToArray()
                                )
    });
