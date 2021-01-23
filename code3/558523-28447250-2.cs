        private bool TryDeleteFile(string fileName)
        {
            string filePath = Path.GetFullPath(fileName);
            var fi = new FileInfo(filePath);
            bool ownerChanged = false;
            bool accessChanged = false;
            bool isDelete = false;
            FileSecurity fs = fi.GetAccessControl();
            Privilege p = new Privilege(Privilege.TakeOwnership);
            try
            {
                p.Enable();
                fs.SetOwner(WindowsIdentity.GetCurrent().User);
                File.SetAccessControl(filePath, fs); //Update the Access Control on the File
                ownerChanged = true;
            }
            catch (PrivilegeNotHeldException ex) { }
            finally { p.Revert(); }
            try
            {
                fs.SetAccessRule(new FileSystemAccessRule(WindowsIdentity.GetCurrent().User, FileSystemRights.FullControl, AccessControlType.Allow));
                File.SetAccessControl(filePath, fs);
                accessChanged = true;
            }
            catch (UnauthorizedAccessException  ex) { }
            if (ownerChanged && accessChanged)
            {
                try
                {
                    fi.Delete();
                    isDelete = true;
                }
                catch (Exception ex) {  }
            }
            return isDelete;
        }
