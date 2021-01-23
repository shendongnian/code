    class TreeNode
    {
        public readonly List<TreeNode> Childs = new List<TreeNode>();
        public readonly string ID;
        public TreeNode Parent;
        public TreeNode(string id)
        {
            this.ID = id;
        }
        public TreeNode GetChild(string id)
        {
            return this.Childs.FirstOrDefault(child => child.ID == id);
        }
    }
