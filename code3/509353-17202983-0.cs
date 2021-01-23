    if (!Roles.RoleExists("Administrator"))
        Roles.CreateRole("Administrator");
 
    if (!Roles.GetRolesForUser(model.UserName).Contains("Administrator"))
        Roles.AddUsersToRole(new[] { model.UserName }, "Administrator");
    }
