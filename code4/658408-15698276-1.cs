    public class Node<T> where T : ICategory
    {
        Node<T> _parentNode;
        List<Node<T>> _children;
        public Node<T> Parent { get { return _parentNode; }}
        public Node<T> Child(int index) { return _children[index]; }
            
        public T Value;
        public Node(T value)
        {
            this.Value = value;
        }
        public void AddChild(T item)
        {
            Node<T> child = new Node<T>(item);
            this._children.Add(child);
            child._parentNode = this;
        }
    }
