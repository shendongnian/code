    List<string> LdapUsers = new List<string>();
    
    if (String.IsNullOrWhiteSpace(domain))
    {
    	string username = WindowsIdentity.GetCurrent().Name;
    	domain = username.Substring(0, username.IndexOf("\\"));
    }
    
    PrincipalContext context;
    if (!String.IsNullOrWhiteSpace(user) && !String.IsNullOrWhiteSpace(password) && !String.IsNullOrWhiteSpace(domain))
    	context = new PrincipalContext(ContextType.Domain, domain, user, password);
    if (!String.IsNullOrWhiteSpace(domain))
    	context = new PrincipalContext(ContextType.Domain, domain);
    else
    	context = new PrincipalContext(ContextType.Domain);
    UserPrincipal userP = new UserPrincipal(context);
    userP.Enabled = true;
    PrincipalSearcher pS = new PrincipalSearcher();
    pS.QueryFilter = userP;
    
    PrincipalSearchResult<Principal> result = pS.FindAll();
    foreach (Principal p in result)
    	LdapUsers.Add(domain + "\\" + p.SamAccountName);
