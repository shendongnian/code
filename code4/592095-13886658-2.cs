        public void DeleteFolder(DirectoryInfo dirInfo)
        {
            //Check for sub Directories
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
            {
                //Call itself to delete the sub directory
                DeleteFolder(di);
            }
            //Delete Files in Directory
            foreach (FileInfo fi in dirInfo.GetFiles())
            {
                fi.Delete();
            }
            //Finally Delete Empty Directory
            dirInfo.Delete();
        }
