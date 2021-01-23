    private void SetEditablePermissionOnConfigFilesFolder(IDictionary savedState)
        {
            if (!Context.Parameters.ContainsKey("installpath")) return;
            //Get the "home" directory of the application
            var path = Path.GetFullPath(Context.Parameters["installpath"]);
            //in my case the necessary files are under a ConfigFiles folder;
            //you can do something similar with individual files
            path = Path.Combine(path, "ConfigFiles");
            var dirInfo = new DirectoryInfo(path);
            var accessControl = dirInfo.GetAccessControl();
            //Give every user of the local machine rights to modify all files
            //and subfolders in the directory
            var userGroup = new NTAccount("BUILTIN\\Users");
            var userIdentityReference = userGroup.Translate(typeof(SecurityIdentifier));
            accessControl.SetAccessRule(
                new FileSystemAccessRule(userIdentityReference,
                                         FileSystemRights.Modify,
                                         InheritanceFlags.ObjectInherit 
                                            | InheritanceFlags.ContainerInherit,
                                         PropagationFlags.None,
                                         AccessControlType.Allow));
            //Commit the changes.
            dirInfo.SetAccessControl(accessControl);
        }
