    private void SaveNodes(TreeNodeCollection nodesCollection, XmlWriter textWriter)
    {
        for (int i = 0; i < nodesCollection.Count; i++)
        {
            TreeNode node = nodesCollection[i];
            if (node.Nodes.Count > 0)
            {
                textWriter.WriteStartElement(node.Text);
                SaveNodes(node.Nodes, textWriter);
                textWriter.WriteEndElement();
            }
            else
            {
                textWriter.WriteAttributeString(node.Text, "Attribute value");
            }
        }
    }
