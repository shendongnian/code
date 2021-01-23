    public class MyRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null && !String.IsNullOrEmpty(authCookie.Value))
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var roles = authTicket.UserData.Split(',')[1];
                return roles.Split(';');
            }
            throw new MemberAccessException("User not logged in");
        }
    }
