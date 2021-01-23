    public class BinaryTree
        {
            public BinaryTree()
            {
                size = 0;
                Root = null; //To hold the main Parent Node
            }
            int size;
            BTNode Root;
    
            public void AddNode(int value)
            {
                size++;
                BTNode NewNode = new BTNode()
                {
                    Value = value
                };
    
                if (this.Root == null)
                {
                    this.Root = NewNode;
                    return;
                }
    
                this.PlaceNewNode(this.Root, NewNode);
            }
    
            public void PlaceNewNode(BTNode RootNode, BTNode NewNode)
            {
                if (NewNode.Value < RootNode.Value)
                {
                    if (RootNode.Left != null)
                    {
                        PlaceNewNode(RootNode.Left, NewNode);
                    }
                    else
                    {
                        RootNode.Left = NewNode;
                        return;
                    }
                }
                else
                {
                    if (RootNode.Right != null)
                    {
                        PlaceNewNode(RootNode.Right, NewNode);
                    }
                    else
                    {
                        RootNode.Right = NewNode;
                        return;
                    }
                }
            }
        }
