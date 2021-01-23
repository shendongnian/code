    using (var context = new PrincipalContext(ContextType.Domain))
    {
    	var name = UserPrincipal.Current.DisplayName;
    	var principal = UserPrincipal.FindByIdentity(context, this.user.Identity.Name);
    	if (principal != null)
    	{
    		this.fullName = principal.GivenName + " " + principal.Surname;
    	}
    	else
    	{
    		this.fullName = string.Empty;
    	}
    }
