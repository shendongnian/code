    string Path = @"C:\Temp Folder\";
    string[] folders = System.IO.Directory.GetDirectories(Path, "*", System.IO.SearchOption.AllDirectories); 
        
           TreeNode treeNode = new TreeNode(Path);          
            TreeNode subNode;
            for (int i = 0; i < folders.Length; i++)
            {
                subNode = new TreeNode(folders[i].ToString());
                treeNode.Nodes.Add(subNode);            
            }
            treeView1.Nodes.Add(treeNode);  
