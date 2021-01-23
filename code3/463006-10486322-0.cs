    public class Node<T> {
        private List<Node<T>> nodes;        
        public T Item { get; private set; }
        public Node(T item) {
            nodes = new List<Node<T>>();
            Item = item;
        }
        
        public IEnumerable<Node<T>> {
            return nodes;
        }
        //Add other things like: `Find(T item)`, `Add(T item)`
    }
