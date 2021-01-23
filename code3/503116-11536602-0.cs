        private void PermissionGet(DirectoryInfo Source, DirectoryInfo Destination)
        {
            string Username;
            DirectorySecurity SourceSecurity = Source.GetAccessControl();
            foreach (FileSystemAccessRule Rules in SourceSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                Username = Rules.IdentityReference.Value;
                PermissionSet(Username, Rules.FileSystemRights, Rules.AccessControlType, Destination);
            }
        }
        private void PermissionSet(string Username, FileSystemRights Permission, AccessControlType Access, DirectoryInfo Destination)
        {
            DirectorySecurity Security = Destination.GetAccessControl();
            Security.AddAccessRule(new FileSystemAccessRule(Username, Permission, Access));
            Destination.SetAccessControl(Security);
        }
