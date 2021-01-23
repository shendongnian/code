    public void AddSubTree(TreeNode treeRoot, RegistryKey registryKeyToAdd)
    {
        var child = new TreeNode(registryKeyToAdd.Name);
        treeRoot.Children.Add(child);
        foreach(var subKeyName in registryKeyToAdd.GetSubKeyNames())
        {
            try
            {
                AddSubTree(child, registryKeyToAdd.OpenSubKey(subKeyName));
            }
            catch(SecurityException e)
            {
                child.Children.Add(new TreeNode(string.Format("{0} - Access denied", subKeyName)));
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
