public static bool UserHasLocalAdminPrivledges(this UserPrincipal up)
{
   SecurityIdentifier id = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
   return up.GetAuthorizationGroups().Any(g => g.Sid == id)
}
