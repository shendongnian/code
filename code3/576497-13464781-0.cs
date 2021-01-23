    public static bool IsUserInRole(string username, string roleName)
    {
      using(var roleRepository = new RoleRepository())
      {
        return roleRepository.Roles.Any(r => r.RoleName == roleName && r.UserRoles.Any(ur => ur.User.UserName == username));
      }
    }
