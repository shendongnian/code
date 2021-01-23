    WindowsIdentity id = WindowsIdentity.GetCurrent();
    var sid = new SecurityIdentifier(WellKnownSidType.AccountDomainUsersSid, id.User.AccountDomainSid);
    var security = dir.GetAccessControl();
    var rule = new FileSystemAccessRule(sid,
    	FileSystemRights.FullControl,
    	InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
    	PropagationFlags.None,
    	AccessControlType.Allow);
    security.AddAccessRule(rule);
    dir.SetAccessControl(security);
