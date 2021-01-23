        private void ConvertXmlNodeToTreeNode(BackgroundWorker worker, DoWorkEventArgs args, XmlNode xmlNode, TreeNodeCollection treeNodes)
        {
            TreeNode newTreeNode = null;
            String nodeText = null;
            if (worker.CancellationPending == true)
            {
                args.Cancel = true;
                return;
            }
            Invoke((MethodInvoker)delegate
            {
                newTreeNode = treeNodes.Add(xmlNode.Name);
            });
            
            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    nodeText = "<?" + xmlNode.Name + " " + xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    nodeText = "<" + xmlNode.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    nodeText = "ATTRIBUTE: " + xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    nodeText = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    nodeText = "<!--" + xmlNode.Value + "-->";
                    break;
            }
            if (!String.IsNullOrEmpty(nodeText))
            {
                Invoke((MethodInvoker)delegate
                {
                    newTreeNode.Text = nodeText;
                });
            }
            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(worker, args, attribute, newTreeNode.Nodes);
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(worker, args, childNode, newTreeNode.Nodes);
            }
        }
