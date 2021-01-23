    private TreeNode FindNode(TreeNode node, string searchText)
    {
      TreeNode result = null;
      
      if (node.Text == searchText)
      {
        result = node;
      }
      else
      {
        foreach(TreeNode child in node.Nodes)
        {
           result = FindNode(child, searchText);
           if (result != null)
           {
             break;
           }
        }  
      }
      return result;
    }
