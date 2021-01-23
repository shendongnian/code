    accessdeny.SetAccessRule(
       new System.Security.AccessControl.FileSystemAccessRule(
       new SecurityIdentifier(WellKnownSidType.WorldSid, null),
       System.Security.AccessControl.FileSystemRights.FullControl,
       System.Security.AccessControl.AccessControlType.Deny));
