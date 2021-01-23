    var roles = new List<string> { "Admin", "Author", "Super" };
    var userRoles = Roles.GetRolesForUser(User.Identity.Name);
    if (userRoles.Any(u => roles.Contains(u))
    {
        //do something
    }
