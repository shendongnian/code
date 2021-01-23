        public void SetFileSystemRights(string target, string group, FileSystemRights permission)
        {
            if (!IsDirectory(target) && !IsFile(target))
                return;
            var oldSecurity = Directory.GetAccessControl(target);
            var newSecurity = new DirectorySecurity();
            newSecurity.SetSecurityDescriptorBinaryForm(oldSecurity.GetSecurityDescriptorBinaryForm());
            var accessRule = new FileSystemAccessRule(group,
                                                      permission,
                                                      InheritanceFlags.None,
                                                      PropagationFlags.NoPropagateInherit,
                                                      AccessControlType.Allow);
            bool result;
            newSecurity.ModifyAccessRule(AccessControlModification.Set, accessRule, out result);
            if (!result) Log.AddError("Something wrong happened");
            accessRule = new FileSystemAccessRule(group,
                                                  permission,
                                                  InheritanceFlags.ContainerInherit |
                                                  InheritanceFlags.ObjectInherit,
                                                  PropagationFlags.InheritOnly,
                                                  AccessControlType.Allow);
            result = false;
            newSecurity.ModifyAccessRule(AccessControlModification.Add, accessRule, out result);
            if (!result) Log.AddError("Something wrong happened");
            Directory.SetAccessControl(target, newSecurity);
            if (result) Log.AddGood("Permissions set for '{0}' on folder '{1}'", group, target);
            if (!result) Log.AddError("Something wrong happened");
        }
