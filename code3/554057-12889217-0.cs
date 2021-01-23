    public static RoleType GetMaxRole()
    {
        var userRoles = Roles.GetRolesForUser();
        var maxRole = userRoles.Max(x => (RoleType)Enum.Parse(typeof(RoleType), x));
        return maxRole;
    }
