                List<int> nodeIdsToMove = new List<int>();
            List<int> nodeIdsToRemove = new List<int>();
            if (comboBox_GroupBy.SelectedItem.ToString() == "None")
            {
                /* Parent nodes */
                foreach(TreeListNode parentNode in treeList_Links.Nodes)
                {
                    nodeIdsToRemove.Add(parentNode.Id);
                    if (parentNode.HasChildren)
                    {
                        /* Child nodes */
                        foreach (TreeListNode childNode in parentNode.Nodes)
                            nodeIdsToMove.Add(childNode.Id);
                    }
                }
                MoveNodes(nodeIdsToMove);
                RemoveNode(nodeIdsToRemove);
