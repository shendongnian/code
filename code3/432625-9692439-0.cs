    if (inXmlNode.HasChildNodes)
    {
        // child nodes
        for (...)
        {
            xNode = inXmlNode.ChildNodes[i];
            inTreeNode.Nodes.Add(new TreeNode(xNode.Name));  // here the leafs are created
            tNode = inTreeNode.Nodes[i];
            AddNode(xNode, tNode);
        }
    }
    else
    {
        // it's a leaf
        inTreeNode.Text = ...  // here it is set
    }
