        public List<string> FindEmptyFolders(string FolderToSearchIn, string FolderNameToSearch, string FileExtension = "")
        {
            List<string> FolderList = System.IO.Directory.GetDirectories(FolderToSearchIn, "*" + FolderNameToSearch + "*", SearchOption.AllDirectories).ToList();
            List<string> EmptyFolders = new List<string>();
            if (string.IsNullOrEmpty(FileExtension))
                FolderList.ForEach(Folder => { if (System.IO.Directory.EnumerateFiles(Folder).Count() == 0) EmptyFolders.Add(Folder); });
            else
                FolderList.ForEach(Folder => { if (System.IO.Directory.EnumerateFiles(Folder, "*." + FileExtension).Count() == 0) EmptyFolders.Add(Folder); });
            return EmptyFolders;
        }
