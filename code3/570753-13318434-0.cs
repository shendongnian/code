    IList<UserRole> GetHigherRoles(UserRole role)
    {
        var roles = new List<UserRole>();
        foreach (var r in Enum.GetValues(typeof(UserRole)))
        {
            if ((UserRole)r >= role)
            {
                roles.Add((UserRole)r);
            }
        }
        return roles;
    }
    IList<UserRole> GetLowerRoles(UserRole role)
    {
        var roles = new List<UserRole>();
        foreach (var r in Enum.GetValues(typeof(UserRole)))
        {
            if ((UserRole)r <= role)
            {
                roles.Add((UserRole)r);
            }
        }
        return roles;
    }
