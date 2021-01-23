    public enum Role
    {
        Administrator,
        Moderator,
        Webmaster,
        Guest
    }
    public static class RoleExt
    {
        public static string AsDisplayString(this Role role)
        {
            switch (role)
            {
                case Role.Administrator: return Resources.RoleAdministrator;
                case Role.Moderator:     return Resources.RoleModerator;
                case Role.Webmaster:     return Resources.RoleWebmaster;
                case Role.Guest:         return Resources.RoleGuest;
                default: throw new ArgumentOutOfRangeException("role");
            }
        }
    }
