    public class SpecialTree<T> : Node<T>
    {
        public SpecialTree() : base() {}
        public SpecialTree(T data) : base(data, null) {}
        public SpecialTree(T data, SpecialTree<T> left, SpecialTree<T> right)
        {
            base.Value = data;
            NodeList<T> children = new NodeList<T>(2);
            children[0] = left;
            children[1] = right;
    
            base.Neighbors = children;
        }
    
        public SpecialTree<T> Left
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (SpecialTree<T>) base.Neighbors[0];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
    
                base.Neighbors[0] = value;
            }
        }
    
        public SpecialTree<T> Right
        {
            get
            {
                if (base.Neighbors == null)
                    return null;
                else
                    return (SpecialTree<T>) base.Neighbors[1];
            }
            set
            {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>(2);
    
                base.Neighbors[1] = value;
            }
        }
    }
