    public class TreeNode
    {
        private readonly List<TreeNode> _children = new List<TreeNode>();
        public TreeNode(string name, params TreeNode[] children)
        {
            Name = name;
            _children.AddRange(children);
        }
        public List<TreeNode> Children { get { return _children; } }
        public string Name { get; set; }
    }
