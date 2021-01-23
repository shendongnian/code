    // This folder only (default)
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.None, PropagationFlags.None, AuditFlags.Success));
    // This folder and subfolders
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit, PropagationFlags.None, AuditFlags.Success));
    // This folder and files
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.ObjectInherit, PropagationFlags.None, AuditFlags.Success));
    // This folder, subfolders and files
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AuditFlags.Success));
    // Subfolders only
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit, PropagationFlags.InheritOnly, AuditFlags.Success));
    // Files only
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AuditFlags.Success));
    // Subfolders and files only
    fSecurity.AddAuditRule(new FileSystemAuditRule(account, FileSystemRights.WriteData | FileSystemRights.Delete | FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AuditFlags.Success));
