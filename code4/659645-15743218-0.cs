    public class Node<T> where T : INode
    {
        private readonly T _item;
        private readonly Lazy<List<Node<T>>> _children = new Lazy<List<Node<T>>>(
            () => new List<Node<T>>());
        public IList<Node<T>> Children { get { return _children.Value; } }
        public Node(T item)
        {
            _item = item;
            ParentNodeId = item.ParentNodeId;
        }
        public void AddChild(T childNode)
        {
            Children.Add(new Node<T>(childNode));
        }
    }
