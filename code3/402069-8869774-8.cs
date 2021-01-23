    var newRolsIds = new List<int> { 1, 2, 5 };
    using (var context = new MyObjectContext())
    {
        var user = context.Users.Include("Roles")
            .Single(u => u.UserId == 3);
        // loads user with roles, for example role 3 and 5
        var newRoles = context.Roles
            .Where(r => newRolsIds.Contains(r.RoleId))
            .ToList();
        user.Roles.Clear();
        foreach (var newRole in newRoles)
            user.Roles.Add(newRole);
        context.SaveChanges();
    }
