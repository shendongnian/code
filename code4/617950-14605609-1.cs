    TreeNode FindNodeByName(TreeNodeCollection NodesCollection , string Name)
            {
              TreeNode returnNode = null; // Default value to return
              foreach (TreeNode checkNode in NodesCollection)
                {
                    if (checkNode.Name == Name)  //checks if this node name is correct
                        returnNode = checkNode;
                    else if (checkNode.Nodes.Count > 0 ) //node has child
                    {
                        returnNode = FindNodeByName(checkNode.Nodes , Name);
                    }
    
                  if (returnNode != null) //check if founded do not continue and break
                  {
                      return returnNode;
                  }
                    
                }
                //not found
                return returnNode;
            }
