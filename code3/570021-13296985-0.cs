    bool isSystem;
    using (var identity = System.Security.Principal.WindowsIdentity.GetCurrent())
    {
        isSystem = identity.IsSystem;
    }
