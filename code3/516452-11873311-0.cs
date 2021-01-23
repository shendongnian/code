    public IEnumerable<PermissionItem> PermissionItems
    {
       get
       {
            return GetPermissionItems();
       }
    }
    static IEnumerable<PermissionItem> GetPermissionItems()
    {
           // Make sure that the permissions have returned.  
           // If they have not then we need to wait for that to happen.
           if (!doneLoadingPermissions.WaitOne(10000))
               throw new ApplicationException("Could not load permissions");
    
           foreach (var item in permissionItemsReadOnly) yield return item;
    }
