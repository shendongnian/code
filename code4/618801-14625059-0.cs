        public class CustomRoleProvider : RoleProvider
        {
            public override void CreateRole(string roleName)
            {
                throw new NotImplementedException();
            }
    
            public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
            {
                throw new NotImplementedException();
            }
        }
    
        interface RoleProvider
        {
    
        }
