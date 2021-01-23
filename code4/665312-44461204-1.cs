    string accountname = @"domain\username";
    string admin = "adminusername";
    string domain = Environment.UserDomainName;
    string password = "password";
    string dc = "WIN2K8DC1";  // example host name of domain controller, could use IP
    // This determines the domain automatically, no need to specify
    // Use the constructor that takes the domain controller name or IP, 
    // admin user name, and password
    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dc, admin, password); 
    UserPrincipal winuser = UserPrincipal.FindByIdentity(ctx, accountname)
    
    if (winuser != null)
    {
        WindowsImpersonationContext wic = Impersonation.doImpersonation(admin, domain, password); //class/function that does the logon of the user and returns the WIC
        if (wic != null)
        {
            winuser.UnlockAccount();
        }
    } 
