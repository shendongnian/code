    [Flags]
    public enum Roles
    {
        None          = 0,
        Administrator = 1,
        Moderator     = 2,
        Webmaster     = 4,
        Guest         = 8
    }
    public static class RolesExt
    {
        public static string AsDisplayString(this Roles roles)
        {
            if (roles == 0)
                return Resources.RoleNone;
            var result = new StringBuilder();
            if ((roles & Roles.Administrator) != 0)
                result.Append(Resources.RoleAdministrator + " ");
            if ((roles & Roles.Moderator) != 0)
                result.Append(Resources.RoleModerator + " ");
            if ((roles & Roles.Webmaster) != 0)
                result.Append(Resources.RoleWebmaster + " ");
            if ((roles & Roles.Guest) != 0)
                result.Append(Resources.RoleGuest + " ");
            return result.ToString().TrimEnd();
        }
    }
