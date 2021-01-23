        private void selectTreeViewItem(int dataGridViewRowIndex)
        {
            expandAllTreeViewNodes();
            setTreeViewItem(dataGridViewRowIndex);
        }
        private void setTreeViewItem(int dataGridViewRowIndex)
        {
            int iterator = 0;
            TreeNode tempNode = testStepTreeView.Nodes[iterator];
            //don't need to actually return the integer...
            iterator = findNode(tempNode, dataGridViewRowIndex, iterator);
            testStepTreeView.Focus();
            nodeFound = false;
        }
        private void expandAllTreeViewNodes()
        {
            if (testStepTreeView.Nodes.Count != 0)
            {
                foreach (TreeNode x in testStepTreeView.Nodes)
                {
                    expandNode(x);
                }
            }
        }
        private void expandNode(TreeNode x)
        {
            if (x.IsExpanded == false)
            {
                x.Expand();
            }
            if (x.Nodes.Count > 0)
            {
                foreach (TreeNode y in x.Nodes)
                {
                    expandNode(y);
                }
            }
        }
        private int findNode(TreeNode tempNode, int dataGridViewRowIndex, int iterator)
        {
            
            if (iterator > dataGridViewRowIndex)
            {
                return iterator;
            }
            if (iterator == dataGridViewRowIndex)
            {
                testStepTreeView.SelectedNode = tempNode;
                nodeFound = true;
                return iterator;
            }
            
            if (tempNode.Nodes.Count != 0)
            {
                iterator++;
                if (iterator > dataGridViewRowIndex)
                {
                    return iterator;
                }
                if (nodeFound == false)
                {
                    iterator = findNode(tempNode.Nodes[0], dataGridViewRowIndex, iterator);
                }
            }
            if (tempNode.NextNode != null)
            {
                iterator++;
                if (iterator > dataGridViewRowIndex)
                {
                    return iterator;
                }
                if (nodeFound == false)
                {
                    iterator = findNode(tempNode.NextNode, dataGridViewRowIndex, iterator);
                }
            }
            return iterator;
        }
