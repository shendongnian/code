     string user = Environment.UserDomainName + "\\" + Environment.UserName;
     RegistrySecurity rs = new RegistrySecurity();
        
     rs.AddAccessRule(new RegistryAccessRule(user, 
         RegistryRights.FullControl, 
         InheritanceFlags.None, 
         PropagationFlags.None, 
         AccessControlType.Allow));
    var key = Microsoft.Win32.Registry.Users.OpenSubKey(Path, RegistryKeyPermissionCheck.ReadWriteSubTree, rs);
