    dir = "C:\test";
    DirectorySecurity security = Directory.GetAccessControl(dir);
    FileSystemAccessRule rule = new FileSystemAccessRule("Account", FileSystemRights.FullControl, AccessControlType.Allow);
    security.AddAccessRule(rule);
   
    Directory.SetAccessControl(dir,security); 
