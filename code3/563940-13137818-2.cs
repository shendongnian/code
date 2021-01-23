    public void AddNode(TreeView parent, string text)
    {
        if (parent != null)
        {
             parent.Nodes.Add(new TreeNode(text + (parent.Nodes.Count + 1).ToString()));
        }
    }
    public void AddChildNode(TreeNode parent)
    {
        if(parent != null)
        {
             string number = parent.Text;
             parent.Nodes.Add(new TreeNode(number + (parent.Nodes.Count + 1).ToString()));   
        }
    }
