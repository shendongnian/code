    private void AddNodeForDirectory(DirectoryInfo directory, TreeNode directoryNode)
    {
        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            TreeNode subDirectoryNode = new TreeNode
            {
                Text = subDirectory.Name,
                NavigateUrl = // some path... I leave this to you 
            };
    
            foreach (FileInfo file in subDirectory.GetFiles())
            {
                TreeNode fileNode = new TreeNode
                {
                    Text = file.Name,
                    NavigateUrl = // some path... I leave this to you
                };  
    
                subDirectoryNode.ChildNodes.Add(fileNode);
            }
            directoryNode.ChildNodes.Add(subDirectoryNode);
            // Here is the recursion
            this.AddNodeForDirectory(subDirectory, subDirectoryNode);
        }
    }
