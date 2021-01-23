    public static bool HasRolesAndPermissions(this IPrincipal instance,
        string roles,
        string permissions,)
    {
      if(user not authenticated)
        return false;
      if(user has any role of Roles)
        return true;
      if(user has any permission of Permissions)
        return true;
    return false;
    }
