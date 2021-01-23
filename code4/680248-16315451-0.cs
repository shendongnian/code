    DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Shahul\Documents\Visual Studio 2010\Projects\TreeView\TreeView\bin\FileExplorer");
    
    private void Form1_Load(object sender, EventArgs e)
    {
        if (directoryInfo.Exists)
        {
            try
            {
                treeView.Nodes.Add(directoryInfo.Name);
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
    
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (file.Exists)
                    {
                        TreeNode nodes = treeView.Nodes[0].Nodes.Add(file.Name);
                    }
                }
    
                if (directories.Length > 0)
                {
                    foreach (DirectoryInfo directory in directories)
                    {
                        TreeNode node = treeView.Nodes[0].Nodes.Add(directory.Name);
                        node.ImageIndex = node.SelectedImageIndex = 0;
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            if (file.Exists)
                            {
                                TreeNode nodes = treeView.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
