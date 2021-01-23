        private void UpdateFileAttributes(DirectoryInfo dInfo)
        {
            // Set Directory attribute
            dInfo.Attributes &= ~FileAttributes.ReadOnly;
            // get list of all files in the directory and clear 
            // the Read-Only flag
            foreach (FileInfo file in dInfo.GetFiles())
            {
                file.Attributes &= ~FileAttributes.ReadOnly;
            }
            // recurse all of the subdirectories
            foreach (DirectoryInfo subDir in dInfo.GetDirectories())
            {
                UpdateFileAttributes(subDir);
            }
        }
