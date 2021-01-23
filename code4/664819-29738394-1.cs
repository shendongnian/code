    PipeSecurity pipeSecurity = new PipeSecurity();
    
    // Allow Everyone read and write access to the pipe.
    pipeSecurity.SetAccessRule(new PipeAccessRule(
        "Authenticated Users",
        new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null),   
        PipeAccessRights.ReadWrite, AccessControlType.Allow));
    
    // Allow the Administrators group full access to the pipe.
    pipeSecurity.SetAccessRule(new PipeAccessRule(
        "Administrators",
        new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null),   
        PipeAccessRights.FullControl, AccessControlType.Allow));
