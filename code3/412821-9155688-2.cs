    string CurrentUser = WindowsIdentity.GetCurrent().Name;
    
    PrincipalContext context = new PrincipalContext(ContextType.Domain, "Domain");
    UserPrincipal upUser = UserPrincipal.FindByIdentity(context, CurrentUser);
    if(upUser != null)
    {
        if (upUser.IsMemberOf("CustomGroup")) 
        {
            // The user belongs to the group
        }
    }
