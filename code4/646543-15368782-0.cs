    FileIOPermission f = new FileIOPermission(FileIOPermissionAccess.Write, myPath);
    try
    {
       f.Demand();
       //permission to write
    }
    catch (SecurityException s)
    {
       //there is no permission to write
    }
