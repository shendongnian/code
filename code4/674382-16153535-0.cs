    public class RolesManagement
    {
        private static readonly Dictionary<string,string> RoleMapping =
            new Dictionary<string,string>
            {
                {"SubUser", "User" },
                {"SubManager", "Manager" },
                {"SubAdmin", "Admin" }
            };
        
        public static IEnumerable<string> BuildRoles(string DesiredRole)
        {
            var UserRoles = Roles.GetAllRoles();
    
            IEnumerable<string> roles;
            roles = UserRoles.Where(x => x.Contains("Sub")).Except(rejectAdmin);
            return roles.Select(r => RoleMapping.ContainsKey(r) ? RoleMapping[r] : r);
        }
    }
