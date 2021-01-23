    using (var ctx = new MyContext())
    {
        var user = ctx.Users.Find(1);
        var role = ctx.Roles.Find(5);
        user.Roles = new List<Role>();
        user.Roles.Add(role);
        ctx.SaveChanges();
    }
