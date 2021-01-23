    var userRoles = Roles.GetRolesForUser(userName);
    var rolesNotAssigned = Roles.GetAllRoles().Except(userRoles);
    if (rolesNotAssigned.Length == 0)
    {
        // user is in all roles   
    }
