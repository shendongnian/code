    class TreeNode<T>
    {
        List<TreeNode<T>> Children;
        T Item {get;set;}
        public TreeNode (T item)
	    {
            Item = item;
	    }
        public TreeNode<T> AddChild(T item)
        {
            TreeNode<T> nodeItem = new TreeNode<T>(item);
            Children.Add(nodeItem);
            return nodeItem;
        }
    }
