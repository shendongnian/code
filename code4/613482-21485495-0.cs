    public static bool IsInAnyRole(this IPrincipal user, string[] roles)
            {
                //Check if authenticated first (optional)
                if (!user.Identity.IsAuthenticated) return false;
                var userRoles = Roles.GetRolesForUser(user.Identity.Name);
                return userRoles.Any(roles.Contains);
            }
