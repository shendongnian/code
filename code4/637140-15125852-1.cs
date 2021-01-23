    public void SetupTree()
    {
        Assembly dataLib = Assembly.Load("Data");
        TreeNode theTree = new TreeNode("Assembly Data");
        foreach (Type type in dataLib.GetTypes())
        {
            LoadAllChildren(dataLib, type, theTree);
        }
        treeView_left.Nodes.Add(theTree);  //Optimisation - bind all nodes in one go rather than adding individually
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
