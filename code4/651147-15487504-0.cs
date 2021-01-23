    var directories = Directory.GetDirectories("c:\\users");
    foreach (string directoryName in directories)
    {
        var directory = new DirectoryInfo(directoryName);
        var node = new TreeNode(directory.Name);
        node.ImageIndex = 1;
        foreach (FileInfo file in directory.GetFiles())
        {
            if (file.Exists)
            {
                var nodes = node.Nodes.Add(file.Name);
                nodes.ImageIndex = 2;
            }
        }
        treeView1.Nodes.Add(node);
    }
