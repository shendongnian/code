    public class ActiveDirectoryGroup
    {
        public static bool IsInAnyRole(string adRoles)
        {
            return adRoles.Split(Convert.ToChar(";")).Any(role => !string.IsNullOrEmpty(role.Trim()) && HttpContext.Current.User.IsInRole(role.Trim()));
            //If list is passed use below
            //return listParameter.Any(role => !string.IsNullOrEmpty(role.Trim()) && HttpContext.Current.User.IsInRole(role.Trim()));
        }
    }
