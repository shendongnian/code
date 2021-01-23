    const string PARENT_ID = "10"; // The ID of the node that has child nodes
    public override void Render(ref XmlTree tree)
    {
      if (this.NodeKey == PARENT_ID) // Rendering the child nodes of the parent folder
      {
        // Render a child node
        XmlTreeNode node = XmlTreeNode.Create(this);
        node.NodeID = "11";
        node.Text = "child";
        node.Icon = "doc.gif";
        node.Action = ...
        tree.Add(node);
      }
      else // Default (Rendering the root)
      {
        // Render the parent folder
        XmlTreeNode node = XmlTreeNode.Create(this);
        node.NodeID = PARENT_ID;
        node.Source = this.GetTreeServiceUrl(node.NodeID);
        node.Text = "parent";
        node.Icon = "folder.gif";
        tree.Add(node);
      }
    }
