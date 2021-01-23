    public void ExpandAll(TreeNodeCollection nodes)
    {
       foreach(TreeNode node in nodes)
       {
          node.Expand(); // expand current node
          ExpandAll(node.Nodes); // expand children
       }
    }
