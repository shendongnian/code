    var newUserIDs = NewUsers.Select(u => u.UserId).Distinct().ToArray();
    var usersInDb = dbcontext.Users.Where(u => newUserIDs.Contains(u.UserId))
                                   .Select(u => u.UserId).ToArray();
    var usersNotInDb = NewUsers.Where(u => !usersInDb.Contains(u.UserId));
    foreach(User user in usersNotInDb){
        context.Add(user);
    }
    dbcontext.SaveChanges();
