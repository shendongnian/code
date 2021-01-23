    string authorizedRolesForAdmin = string.Concat(",", ConfigurationManager.AppSettings["AdminScreenRoles"]), ",");
    string authorizedRolesForLogs = string.Concat(",", ConfigurationManager.AppSettings["LogsScreenRoles"]), ",");
    string searchString = string.Concat(",", roleName, ",");
        if ((authorizedRolesForAdmin.Contains(roleName)) || (authorizedRolesForLogs.Contains(roleName)))
        {
            //Has access to at least one page
        }
