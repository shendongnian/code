    private void Form1_Load(object sender, EventArgs e)
        {
            if (directoryInfo.Exists)
            {
                try
                {
                    treeView.Nodes.Add(LoadDirectory(directoryInfo));                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private TreeNode LoadDirectory(DirectoryInfo di)
        {
            if (!di.Exists)
                return null;
            TreeNode output = new TreeNode(di.Name, 0, 0);
            foreach (var subDir in di.GetDirectories())
            {
                try
                {
                    output.Nodes.Add(LoadDirectory(subDir));
                }
                catch (IOException ex)
                {
                    //handle error
                }
                catch { }
            }
            foreach (var file in di.GetFiles())
            {
                if (file.Exists)
                {
                    output.Nodes.Add(file.Name);
                }
            }
            return output;
        }
    }
