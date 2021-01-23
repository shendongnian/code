        private void SaveNodes(TreeNodeCollection nodesCollection, XmlWriter textWriter)
        {
            foreach (var node in nodesCollection.OfType<TreeNode>().Where(x => x.Nodes.Count == 0))
                textWriter.WriteAttributeString(node.Name, "Attribute value");
            foreach (var node in nodesCollection.OfType<TreeNode>().Where(x => x.Nodes.Count > 0))
            {
                textWriter.WriteStartElement(node.Name);
                SaveNodes(node.Nodes, textWriter);
                textWriter.WriteEndElement();
            }
        }
