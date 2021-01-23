    class Node
    {
        Node parent;
        List<Node> children = new List<Node>();
    
        public void Add(Node child)
        {
            if (child.Parent != null)
                // throw exception or call child.Parent.Remove(child)
    
            children.Add(child);
            child.Parent = this;
        }
    
        public void Remove(Node child)
        {
            if (child.Parent != this)
               // throw exception
            children.Remove(child);
            child.Parent = null;
        }
    }
