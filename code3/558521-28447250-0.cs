        private void TryDeleteFile(string fileName)
        {
            string filePath = Path.GetFullPath(fileName);
            var fi = new FileInfo(filePath);
            bool ownerChanged = false;
            bool accessChanged = false;
            FileSecurity fs = fi.GetAccessControl(); // AccessControlSections.Owner
            Privilege p = new Privilege(Privilege.TakeOwnership);
            try
            {
                p.Enable();
                SecurityIdentifier cu = WindowsIdentity.GetCurrent().User;
                fs.SetOwner(cu);
                File.SetAccessControl(filePath, fs); //Update the Access Control on the File
                ownerChanged = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                p.Revert();
            }
            try
            {
                fs = fi.GetAccessControl();
                SecurityIdentifier cu = WindowsIdentity.GetCurrent().User;
                fs.SetAccessRule(new FileSystemAccessRule(cu, FileSystemRights.FullControl, AccessControlType.Allow));
                File.SetAccessControl(filePath, fs);
                accessChanged = true;
            }
            catch (Exception ex)
            {
            }
            if (ownerChanged && accessChanged)
            {
                try
                {
                    fi.Delete(); //File.Delete(fullPath);
                }
                catch (Exception ex)
                {
                }
            }
        }
