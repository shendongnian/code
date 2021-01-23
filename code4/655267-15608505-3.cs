    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain))
    {
        // Search the directory for the new object. 
        UserPrincipalEx inetPerson = UserPrincipalEx.FindByIdentity(ctx, IdentityType.SamAccountName, "someuser");
        // you can easily access the Manager or Department now
        string department = inetPerson.Department;
        string manager = inetPerson.Manager;
    }        
