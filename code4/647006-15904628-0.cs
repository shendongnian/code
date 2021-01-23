    // This will impersonate the logged in user in order to get whichever username you require GIVEN the logged in user has AD read/querying rights.
    System.Web.HttpContext.Current.Request.LogonUserIdentity.Impersonate();
    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
        {
        UserPrincipal up = UserPrincipal.FindByIdentity(ctx, userName);
        return up;
        }
