    public void SetupTree()
    {
        Assembly dataLib = Assembly.Load("Data");
        TreeNode parentNode = new TreeNode("Assembly Data");
        treeView_left.Nodes.Add(parentNode);
        foreach (Type type in dataLib.GetTypes())
        {
            LoadAllChildren(dataLib, type, parentNode);
        }
    }
    
    private void LoadAllChildren(Assembly dataLib,Type type, TreeNode parentNode)
    {
        if (type.IsPublic && type.IsClass)
        {            
            TreeNode node = new TreeNode(type.Name);
            parentNode.Nodes.Add(node);           
    
            var types = dataLib.GetTypes().Where(x => x.IsSubclassOf(type));
            foreach (Type t in types)
            {
                LoadAllChildren(dataLib, t, node);
            }
        }
    }
