    public class MyRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            var roles = username('-')[1];
            return roles.Split(';');
        }
    }
