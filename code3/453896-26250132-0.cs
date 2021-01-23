    PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, "name", "container");
    UserPrincipals user = UserPrincipals.FindByIdentity(domainContext, "ad_user_name");
    DirectoryEntry dirEntry = (user.GetUnderlyingObject() as DirectoryEntry);
    dirEntry.InvokeSet("TerminalServicesProfilePath", "yourpath");
    dirEntry.CommitChanges();
