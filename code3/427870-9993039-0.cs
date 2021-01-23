    try
    {                                
        DirectoryEntry directoryEntry = new DirectoryEntry(ACTIVE_DIRECTORY_PATH, DOMAIN_USERNAME, DOMAIN_PASWORD, AuthenticationTypes.Secure);
                    
        System.Security.Principal.IdentityReference newOwner = new System.Security.Principal.NTAccount("Everyone").Translate(typeof(System.Security.Principal.SecurityIdentifier));
        ActiveDirectoryAccessRule rule = new ActiveDirectoryAccessRule(newOwner,ActiveDirectoryRights.Delete | ActiveDirectoryRights.DeleteChild | ActiveDirectoryRights.DeleteTree, System.Security.AccessControl.AccessControlType.Deny);
        directoryEntry.ObjectSecurity.RemoveAccessRule(rule);
        
        directoryEntry.CommitChanges();                
    }
    catch (Exception ex)
    {
        // log the error
    }
