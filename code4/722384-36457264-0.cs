    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "XXXX.XXX.com")) {
    	using (UserPrincipal user = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username))
    	{
    		if (user != null)
    		{
    			user.ChangePassword(currentPassword, newPassword);
    		}
    		else
    		{
    			throw new Exception(string.Format("Username not found: {0}", username));
    		}
    	}
    }
