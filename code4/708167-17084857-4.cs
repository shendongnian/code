    using (var context = new PrincipalContext( ContextType.Domain)) 
    {
        using (var aduser = UserPrincipal.FindByIdentity( context,IdentityType.SamAccountName, HttpContext.User.Identity.Name))
        {
            ...
        }
    }
