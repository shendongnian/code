     public static bool HaveWritePermissionsForFolder(string path)
        {
            var rules = Directory.GetAccessControl(Path.GetDirectoryName(Path.GetDirectoryName(path))).GetAccessRules(true, true, typeof(SecurityIdentifier));
            bool allowwrite = false;
            bool denywrite = false;
            foreach (FileSystemAccessRule rule in rules)
            {
                if (rule.AccessControlType == AccessControlType.Deny &&
                    (rule.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData &&
                    (groups.Contains(rule.IdentityReference) || rule.IdentityReference.Value == sidCurrentUser)
                    )
                {
                    denywrite = true;
                }
                if (rule.AccessControlType == AccessControlType.Allow &&
                    (rule.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData &&
                    (groups.Contains(rule.IdentityReference) || rule.IdentityReference.Value == sidCurrentUser)
                    )
                {
                    allowwrite = true;
                }
            }
            if (allowwrite && !denywrite)
                return true;
            return false;
        }
