    DirectoryEntry userEntry = userPrincipal.GetUnderlyingObject() as DirectoryEntry;
    
    if (userEntry != null)
    {
        bool isManager = userEntry.Properties["directReports"].Count > 0;
        bool isManaged = userEntry.Properties["manager"].Count > 0;
        // Perform further processing...
    }
