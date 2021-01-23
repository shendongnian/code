    UsersContext db = new UsersContext();
    var userdata = db.UserDetails.Include(x => x.UserSchool)
                                 .Include(x => x.UserCourse)
                                 .Include(x => x.Country)
                                 .Where(x => x.UserId == WebSecurity.CurrentUserId)
                                 .FirstOrDefault();
