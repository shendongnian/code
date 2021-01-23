        public class CustomRoleProvider : RoleProvider
        {
            public void CreateRole(string roleName)
            {
                throw new NotImplementedException();
            }
    
            public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
            {
                throw new NotImplementedException();
            }
        }
    
        interface RoleProvider
        {
               void CreateRole(string roleName);
               bool DeleteRole(string roleName, bool throwOnPopulatedRole);
        }
