    public interface IRoleProvider
    {
        void CreateRole(string roleName);
            
        bool DeleteRole(string roleName, bool throwOnPopulatedRole);
    }
