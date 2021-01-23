    if (RoleManager.IsUserUnrestricted(userId)
    ||  element.AllowedRoles.Split(',')
               .Any(item => roleManager.IsUserInRole(userId, item.Trim()))) {
        ...
    }
