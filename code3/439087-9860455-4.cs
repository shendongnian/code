    class TreeNode : ICollection<TreeNode>
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
        //
        // The rest of the class is must-have implementations for ICollection<TreeNode>
        // So they can't be omitted, even though you do not require them
        //
        public IEnumerator<TreeNode> GetEnumerator()
        {
            return this._childs.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public void Clear()
        {
            foreach (var child in this._childs)
            {
                child.Value.Parent = null;
            }
            this._childs.Clear();
        }
        public bool Contains(TreeNode item)
        {
            return this._childs.ContainsKey(item.ID);
        }
        public void CopyTo(TreeNode[] array, int arrayIndex)
        {
            this._childs.Values.CopyTo(array, arrayIndex);
        }
        public bool Remove(TreeNode item)
        {
            return this._childs.Remove(item.ID);
        }
        public int Count
        {
            get { return this._childs.Count; }
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
    }
