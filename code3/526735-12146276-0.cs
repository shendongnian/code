    public void AddNode(Tree tree, Node nodeToAdd, int depth)
    {
      //you might need to add a special case to handle adding the root node
      Node iterator = tree.RootNode;  
      for(int i = 0; i < depth; i++)
      {
        iterator = iterator.GetLastChild(); //I assume this method won't exist, but you'll know what to put here
      }
    
      iterator.AddChild(nodeToAdd);
    }
