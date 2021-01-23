    public class LinkedList<T>
    {
        private List<LinkedListNode<T>> nodes = new List<LinkedListNode<T>>();
    }
    public class LinkedListNode<T>
    {
        public LinkedListNode<T> Previous { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public T Item { get; set; }
    }
    public class MyClass
    {
        // Some Properties
    }
