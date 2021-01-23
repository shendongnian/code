    protected override void OnAfterUninstall(IDictionary savedState)
        {
            base.OnAfterUninstall(savedState);
            string sFolder = Path.GetDirectoryName(Context.Parameters["assemblypath"]);
            string sUsername = "NT AUTHORITY\\LOCALSERVICE";
            DirectoryInfo myDirectoryInfo = new DirectoryInfo(sFolder);
            DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
            myDirectorySecurity.AddAccessRule(
                new FileSystemAccessRule(
                    sUsername, FileSystemRights.Read | 
                    FileSystemRights.Write | 
                    FileSystemRights.Modify, InheritanceFlags.ContainerInherit | 
                    InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
            myDirectoryInfo.SetAccessControl(myDirectorySecurity);
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
           DeleteDirectory(Path.Combine(appPath, "DB"));
            DeleteDirectory(appPath);
        }
        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                if(file.Contains("app.exe")) continue;
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            Directory.Delete(target_dir, false);
        } 
