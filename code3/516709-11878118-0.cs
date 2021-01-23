    if (Page.User.IsInRole("Admin") && Page.User.IsInRole("Editor") && Page.User.IsInRole("Author") && Page.User.IsInRole("User"))
    {
      //
    }
        //Only for users that are in all roles
        if (Roles.GetAllRoles().Length == Roles.GetRolesForUser().Length)
        {
        }
