    void expandNodePath(TreeNode node)
            {
                if (node == null)
                    return;
                if (node.Level != 0) //check if it is not root
                {
                    node.Expand();
                    expandNodePath(node.Parent);
                }
                else
                {
                    node.Expand(); // this is root 
                }
                
            }
