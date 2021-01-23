        public void KeepTheseFolders(DirectoryInfo dirInfo)
        {
            DeleteFolder(new DirectoryInfo("Path1"), false);
            DeleteFolder(new DirectoryInfo("Path2"), false);
            DeleteFolder(new DirectoryInfo("Path3"), false);
            DeleteFolder(new DirectoryInfo("Path4"), false);
        }
        public void DeleteFolder(DirectoryInfo dirInfo, bool deleteDirectory)
        {
            //Check for sub Directories
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
            {
                //Call itself to delete the sub directory
                DeleteFolder(di, true);
            }
            //Delete Files in Directory
            foreach (FileInfo fi in dirInfo.GetFiles())
            {
                fi.Delete();
            }
            //Finally Delete Empty Directory if optioned
            if (deleteDirectory)
            {
                dirInfo.Delete();
            }
        }
