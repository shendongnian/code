    public class SNode
    {
        public String Name { get; set; }
        private readonly List<SNode> _Nodes = new List<SNode>();
        public ICollection<SNode> Nodes { get { return _Nodes; } }
    }
