    // How to access a specific app pool
    DirectoryEntry appPools = new DirectoryEntry("IIS://" + serverName + "/w3svc/apppools", adminUsername, adminPassword);
    foreach (DirectoryEntry AppPool in appPools.Children)
    {
        if (appPoolName.Equals(AppPool.Name, StringComparison.OrdinalIgnoreCase))
        {
            // access the properties of AppPool...
        }
    }
