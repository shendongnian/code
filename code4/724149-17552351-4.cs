    public static class SecurityHelpers
    {
        public static IEnumerable<object> UserRoles()
        {
            var currentUser = HttpContext.Current.User.Identity.Name;
            var roles = Roles.Providers["MemberAccountRoleProvider"]; //Custom Role Provider Name
            return currentUser != null ? roles.GetRolesForUser(currentUser).Cast<object>().ToArray() : null;
        }
    }
