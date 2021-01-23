    public class TreeNode<T>
    {
        private T _item;
        private TreeNode<T> _parentNode;
        private List<TreeNode<T>> _children;
        public TreeNode(T item)
        {
            _item = item;
        }
        public void SetParentNode(T parent)
        {
            _parentNode.Item = parent;
        }
        public T Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public void AddChild(T child)
        {
            _children.Add(new TreeNode<T>(child));
        }
        public void RemoveChild(T child)
        {
            var node = _children.FirstOrDefault(e => e.Item.Equals(child));
            if (node != null)
                _children.Remove(node);
        }
    }
