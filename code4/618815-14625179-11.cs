    public class CustomRoleProvider : IRoleProvider
    {
        public void IRoleProvider.CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
    
        public bool IRoleProvider.DeleteRole(
            string roleName, 
            bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
    }
