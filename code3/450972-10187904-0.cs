    public override void DenyAccessInherited(string FolderPath,string DomainAndSamAccountName)
        {
            using (Impersonator imp = new Impersonator(this.connection.GetSamAccountName(), this.connection.GetDomain(), this.connection.Password))
            {
                FileSystemAccessRule rule = new FileSystemAccessRule(DomainAndSamAccountName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, System.Security.AccessControl.PropagationFlags.InheritOnly, AccessControlType.Deny);
                DirectoryInfo di = new DirectoryInfo(FolderPath);
                DirectorySecurity security = di.GetAccessControl(AccessControlSections.All);
                bool modified;
                security.ModifyAccessRule(AccessControlModification.Add, rule, out modified);
                if (modified)
                    di.SetAccessControl(security);
                
            }
        }
