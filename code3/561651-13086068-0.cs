    SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
    string pathVersioningDat = ConfigurationManager.GetPath("versioning.dat", true);
    FileSystemAccessRule rule = new FileSystemAccessRule(sid, FileSystemRights.FullControl, AccessControlType.Allow);
    FileSecurity fSecurity = File.GetAccessControl(pathVersioningDat);
    fSecurity.SetAccessRule(rule);
    File.SetAccessControl(pathVersioningDat, fSecurity);
