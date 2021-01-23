    public class WrappedNode
    {
        public string Name { get; set; }
        public ObservableCollection<WrappedNode> Nodes { get; set; }
        public WrappedNode()
        {
            Nodes = new ObservableCollection<WrappedNode>();
        }        
    }
