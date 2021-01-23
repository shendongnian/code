    var sid = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null); 
    Security.AddAccessRule(
       new FileSystemAccessRule(
           sid,
           FileSystemRights.Modify,
           InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
           PropagationFlags.None,
           AccessControlType.Allow));
