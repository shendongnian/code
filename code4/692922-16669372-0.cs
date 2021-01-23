        private void BuildTree(TreeView treeView, XDocument doc)
        {
            TreeNode treeNode = new TreeNode(doc.Root.Name.LocalName);
            treeView.Nodes.Add(treeNode);
            BuildNodes(treeNode, doc.Root);
        }
 
        private void BuildNodes(TreeNode treeNode, XElement element)
        {
            foreach (XNode child in element.Nodes())
            {
                switch (child.NodeType)
                {
                    case XmlNodeType.Element:
                        XElement childElement = child as XElement;
                        TreeNode childTreeNode = new TreeNode(childElement.Name.LocalName);
                        treeNode.Nodes.Add(childTreeNode);
                        BuildNodes(childTreeNode, childElement);
                        break;
                    case XmlNodeType.Text:
                        XText childText = child as XText;
                        treeNode.Nodes.Add(new TreeNode(childText.Value));
                        break;
                }
            }
        }
    }
