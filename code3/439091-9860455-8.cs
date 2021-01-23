    class TreeNode : IEnumerable<TreeNode>
    {
        private readonly Dictionary<string, TreeNode> _childs = new Dictionary<string, TreeNode>();
        public readonly string ID;
        public TreeNode Parent { get; private set; }
        public TreeNode(string id)
        {
            this.ID = id;
        }
        public TreeNode GetChild(string id)
        {
            return this._childs[id];
        }
        public void Add(TreeNode item)
        {
            if (item.Parent != null)
            {
                item.Parent._childs.Remove(item.ID);
            }
            item.Parent = this;
            this._childs.Add(item.ID, item);
        }
        public IEnumerator<TreeNode> GetEnumerator()
        {
            return this._childs.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public int Count
        {
            get { return this._childs.Count; }
        }
    }
