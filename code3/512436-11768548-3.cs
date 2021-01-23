     string user = Environment.UserDomainName + "\\" + Environment.UserName
            RegistryAccessRule rule = new RegistryAccessRule(user,
            RegistryRights.FullControl,
            AccessControlType.Allow);        
            RegistrySecurity security = new RegistrySecurity();
            security.AddAccessRule(rule);
            var key = Microsoft.Win32.Registry.Users.OpenSubKey(Path, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            key.SetAccessControl(security);
