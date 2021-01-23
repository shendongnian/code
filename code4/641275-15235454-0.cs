     System.IO.FileInfo info = new System.IO.FileInfo(path);
     if(info.Exists)
     {
          System.Security.Permissions.FileIOPermission permission =
               new System.Security.Permissions.FileIOPermission(
                   System.Security.Permissions.FileIOPermissionAccess.AllAccess, path);
           permission.Demand();
     }
     else{ 
          throw new System.IO.FileNotFoundException(path);
     }
