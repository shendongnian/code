    public static IEnumerable<string> BuildRoles(string DesiredRole)
    {
        var UserRoles = Roles.GetAllRoles();
        IEnumerable<string> roles;
        roles = UserRoles.Where(x => x.Contains("Sub")).Except(rejectAdmin).Select(x=>x.Replace("Sub","");
        return roles;
    }
