    class Node : INotifyPropertyChanged
    {
        public Node()
        {
            Children = new List<Node>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            var temp = PropertyChanged;
            if (temp != null)
                temp(this, new PropertyChangedEventArgs(name));
        }
        public IList<Node> Children { get; private set; }
        public void AddChild(Node node)
        {
            node.PropertyChanged += ChildPropertyChanged;
            Children.Add(node);
        }
        void ChildPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Modified")
                Modified |= ((Node)sender).Modified;
        }
        bool _modified = false; 
        public bool Modified 
        {
            get { return _modified; } 
            set 
            {
                if (_modified != value)
                {
                    _modified = value;
                    OnPropertyChanged("Modified");
                }
            } 
        }
