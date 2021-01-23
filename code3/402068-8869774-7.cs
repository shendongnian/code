    using (var context = new MyObjectContext())
    {
        context.ContextOptions.LazyLoadingEnabled = false;
        var user = context.Users.Single(u => u.UserId == 3);
        var role = context.Roles.Single(r => r.RoleId == 5);
        user.Roles = new List<Role>(); // necessary, if you are using POCOs
        user.Roles.Add(role);
        context.SaveChanges();
    }
