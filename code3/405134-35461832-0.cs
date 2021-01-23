    static void SetFullControlPermissionsToEveryone(string path)
    {
        const FileSystemRights rights = FileSystemRights.FullControl;
        var allUsers = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
        // Add Access Rule to the actual directory itself
        var accessRule = new FileSystemAccessRule(
            allUsers,
            rights,
            InheritanceFlags.None,
            PropagationFlags.NoPropagateInherit,
            AccessControlType.Allow);
        var info = new DirectoryInfo(path);
        var security = info.GetAccessControl(AccessControlSections.Access);
        bool result;
        security.ModifyAccessRule(AccessControlModification.Set, accessRule, out result);
        if (!result)
        {
            throw new InvalidOperationException("Failed to give full-control permission to all users for path " + path);
        }
        // add inheritance
        var inheritedAccessRule = new FileSystemAccessRule(
            allUsers,
            rights,
            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
            PropagationFlags.InheritOnly,
            AccessControlType.Allow);
        bool inheritedResult;
        security.ModifyAccessRule(AccessControlModification.Add, inheritedAccessRule, out inheritedResult);
        if (!inheritedResult)
        {
            throw new InvalidOperationException("Failed to give full-control permission inheritance to all users for " + path);
        }
        info.SetAccessControl(security);
    }
