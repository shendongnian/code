    class TreeNodeEx : TreeNode
    {
        public void Remove()
        {
            base.Remove();
            // what you want to do
            UpdateNode(this.Parent);
        }
    }
