    var identityName = HttpContext.Current.User.Identity.Name;
    using (HostingEnvironment.Impersonate())
    {
        using (var context = new PrincipalContext(ContextType.Domain, "yourDomain", null, ContextOptions.Negotiate | ContextOptions.SecureSocketLayer))
		using (var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, identityName))
        {
            emailAddress = userPrincipal.EmailAddress;
            lastname = userPrincipal.Surname;
            firstname = userPrincipal.GivenName;
        }
    }
