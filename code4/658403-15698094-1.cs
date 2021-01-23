    public class TreeNode<T>
    {
        private T _item;
        private TreeNode<T> _parentNode;
        private List<TreeNode<T>> _children;
        public TreeNode(T item)
        {
            _item = item;
        }
        private void SetParentNode(T parent)
        {
            _parentNode.Item = parent;
        }
        private T Item
        {
            get { return _item; }
            set { _item = value; }
        }
        private void AddChild(T child)
        {
            _children.Add(new TreeNode<T>(child));
        }
        private void RemoveChild(T child)
        {
            var node = _children.FirstOrDefault(e => e.Item.Equals(child));
            if (node != null)
                _children.Remove(node);
        }
    }
