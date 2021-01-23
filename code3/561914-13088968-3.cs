    class Node
    {
        public Node()
        {
            Children = new List<Node>();
        }
        public IList<Node> Children { get; private set; }
        bool _modified = false; 
        public bool Modified 
        {
            get { return _modified; } 
            set 
            {
                if (_modified != value)
                {
                    _modified = value;
                    if (_modified == true)
                        Bus<WasModified>.Raise(this, new WasModified());
                }
            } 
        }
    }
