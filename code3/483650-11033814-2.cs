    internal static void FillTreeViewWithPlugins(TreeView p_TreeView, Type p_Type, IList<AbstractEnvChecker> p_List)
    {
        Dictionary<string, TreeNode> categoryNodes = new Dictionary<string, TreeNode>();
        TreeNode v_TreeNode;
        if (p_TreeView != null)
        {
            p_TreeView.Nodes.Clear();
            foreach (object p_Item in p_List)
            {
                if (p_Item.GetType().IsSubclassOf(p_Type))
                {
                    if (!categoryNodes.ContainsKey(p_Item.Category))
                        categoryNodes[p_Item.Category] = new TreeNode(p_Item.Category);
                    v_TreeNode = null;
                    v_TreeNode = AddPluginNode(categoryNodes[p_Item.Category], p_Item as AbstractEnvChecker);    
                }
            }
            foreach (string cat in categoryNodes.Keys)
                p_TreeView.Nodes.Add(categoryNodes[cat]);
        }
    }
