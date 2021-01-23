    private TreeNode CheckForSubFolders(string path)
        {
    
            TreeNode folder = new TreeNode(path);
            string dir = path.TrimEnd(new char[] { '\\' });
            int index = dir.LastIndexOf('\\');
            folder.Text = dir.Substring(index + 1);
    
            //But I think that it is OK to use folder.Text = Path.GetFileName(path); 
            //since the filename of some file will never be passed to the CheckForSubFolders method         
    
            foreach(var subdirectory in Directory.GetDirectories(path))
            {
    
                folder.Nodes.Add(CheckForSubFolders(subdirectory));
            }
    
            folder.ImageIndex = 0;
            folder.SelectedImageIndex = 1;
            return folder;
        }
