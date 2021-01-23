    public TreeNode AddChildNode(TreeNode parent, string name)
    {
        var child = new TreeNode(name);
        parent.Children.Add(child);
        return child;
    }
    public void AddSubTree(TreeNode treeRoot, RegistryKey registryKeyToAdd)
    {
        var child = AddChildNode(treeRoot, registryKeyToAdd.Name);
    
        foreach(var subKeyName in registryKeyToAdd.GetSubKeyNames())
        {
            try
            {
                AddSubTree(child, registryKeyToAdd.OpenSubKey(subKeyName));
            }
            catch(SecurityException e)
            {
                AddChildNode(child, string.Format("{0} - Access denied", subKeyName));
            }
        }
    }
    
    public TreeNode BuildRegistryTree()
    {
        var root = new TreeNode("Computer");
        AddSubTree(root, Registry.CurrentUser);
        AddSubTree(root, Registry.LocalMachine);
        return root;
    }
