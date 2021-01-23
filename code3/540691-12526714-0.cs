    private void AddNodesRecursive(TreeNode parent, object childData)
    {
        string strChildNode = string.Empty;
        XmlElement childDoc = null;
        if (parent != null)
        {
            if ((childData as string) != null)
            {
                parent.ChildNodes.Add(new TreeNode((childData as string)));
                return;
            }
            childDoc = childData as XmlElement;
            if (childDoc != null)
            {
                TreeNode subParent = new TreeNode(childDoc.InnerText);
                parent.ChildNodes.Add(subParent);
                foreach (XmlElement grandChild in childDoc.ChildNodes)
                    AddNodesRecursive(subParent, grandChild);
            }
        }
    }
