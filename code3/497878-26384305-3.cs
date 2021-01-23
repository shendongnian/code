        public override bool IsUserInRole(string username, string roleName)
        {
            // Case-insensitive comparison for compatibility with RolePrincipal class
            return thisGetRolesForUser(username).Contains(roleName, 
                                StringComparer.OrdinalIgnoreCase);
        }
