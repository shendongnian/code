    static bool SetAcl()
    {
        FileSystemRights Rights = (FileSystemRights)0;
        Rights = FileSystemRights.FullControl;
        // *** Add Access Rule to the actual directory itself
        FileSystemAccessRule AccessRule = new FileSystemAccessRule("Users", Rights,
                                    InheritanceFlags.None,
                                    PropagationFlags.NoPropagateInherit,
                                    AccessControlType.Allow);
        DirectoryInfo Info = new DirectoryInfo(destinationDirectory);
        DirectorySecurity Security = Info.GetAccessControl(AccessControlSections.Access);
        bool Result = false;
        Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);
        if (!Result)
            return false;
        // *** Always allow objects to inherit on a directory
        InheritanceFlags iFlags = InheritanceFlags.ObjectInherit;
        iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
        // *** Add Access rule for the inheritance
        AccessRule = new FileSystemAccessRule("Users", Rights,
                                    iFlags,
                                    PropagationFlags.InheritOnly,
                                    AccessControlType.Allow);
        Result = false;
        Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);
        if (!Result)
            return false;
        Info.SetAccessControl(Security);
        return true;
    }
