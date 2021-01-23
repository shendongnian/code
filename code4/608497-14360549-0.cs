    public class MyService : Service { 
        public object Get(UserRoles request) {
            var session = this.GetSession();
            return new UserRolesResponse {
                Roles = session.Roles,
                Permissions = session.Permissions,
            };
        }
    }
