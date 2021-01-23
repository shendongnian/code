        private void SelectLink(int linkID, RadTreeNodeCollection rootNodes)
        {
            var node = rootNodes.FindNodeByValue(linkID.ToString());
            if (node != null)
            {
                node.Selected = true;
                node.Expanded = true;
                node.ExpandParentNodes();
                node.Focus();
                ... Do some other work ...
                return;
            }
            // for each node with children  
            foreach (RadTreeNode item in rootNodes.Cast<RadTreeNode>().Where(item => item.Nodes.Count > 0))
            {
                // Recursive call to self to walk the tree
                SelectLink(linkID, item.Nodes);
            }
        }
