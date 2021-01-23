    var newRolsIds = new List<int> { 1, 2, 5 };
    using (var context = new MyObjectContext())
    {
        var user = context.Users.Include("Roles")
            .Single(u => u.UserId == 3);
        // loads user with roles, for example role 3 and 5
        foreach (var role in user.Roles.ToList())
        {
            // Remove the roles which are not in the list of new roles
            if (!newRoleIds.Contains(role.RoleId))
                user.Roles.Remove(role);
            // Removes role 3 in the example
        }
        foreach (var newRoleId in newRoleIds)
        {
            // Add the roles which are not in the list of user's roles
            if (!user.Roles.Any(r => r.RoleId == newRoleId))
            {
                var newRole = new Role { RoleId = newRoleId };
                context.Roles.Attach(newRole);
                user.Roles.Add(newRole);
            }
            // Adds roles 1 and 2 in the example
        }
        // The roles which the user was already in (role 5 in the example)
        // have neither been removed nor added.
        context.SaveChanges();
    }
