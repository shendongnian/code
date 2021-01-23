    var identity = new WindowsIdentity(string sUserPrincipalName);
    // then use this method to check the Identity against any Active Directory group.
    public static bool UserIsInRole(WindowsIdentity identity, string group)
    {
        try
        {
            return new WindowsPrincipal(identity).IsInRole(group);
        }
        catch (Exception ex)
        {
            //Error checking role membership
            return false;
        }
    }
