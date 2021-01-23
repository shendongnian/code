    using (var context = new MyObjectContext())
    {
        var user = context.Users.Single(u => u.UserId == 3);
        var role = context.Roles.Single(r => r.RoleId == 5);
        user.Roles.Add(role);
        context.SaveChanges();
    }
