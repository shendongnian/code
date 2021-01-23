    try {
            FileIOPermission fileIOPermission = new FileIOPermission(FileIOPermissionAccess.AllAccess, myDocFolderFile);
            fileIOPermission.Demand();
        } catch (SecurityException se) {
            Debug.WriteLine(se.ToString());
        }
