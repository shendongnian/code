    CodeImpersonate codeImpersonate = null;
    try
    {
    	codeImpersonate = new CodeImpersonate();
    	var isLoggedIn = codeImpersonate.ImpersonateValidUser(AppConfigs.OfficeUser, AppConfigs.OfficeUeerDomnia, AppConfigs.OfficeUserPass);
    
    	if (isLoggedIn)
    	{
    		//Do your office work....
    	}
    	else
    		throw new InvalidOperationException("Login failed for office user.");
    }
    finally
    {
    	if (codeImpersonate != null)
    		codeImpersonate.UndoImpersonation();
    	codeImpersonate = null;
    }
