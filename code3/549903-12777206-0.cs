         try
        {
            var permission = new RegistryPermission(RegistryPermissionAccess.Read, @"PATH\TO\YOUR\KEY");
            permission.Demand();
    
    // your code here
    
    
        }
        catch (System.Security.SecurityException ex)
        {
            return;
        }
